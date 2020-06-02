using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SPC.Core
{
    public abstract class SpcDeviceContainer<TDevice> : SpcDeviceContainerBase
        where TDevice : SpcDeviceBase
    {
        #region Public Properties

        new public TDevice this[string key]
        {
            get
            {
                try
                {
                    return (TDevice)base[key];
                }
                catch
                {
                    return null;
                }
            }
        } 

        #endregion


        #region Constructor

        public SpcDeviceContainer() : base()
        {
            
        }

        public SpcDeviceContainer(EDevice device, EDeviceType type, string readBlockKey)
           : this(device, type, 0x0000, readBlockKey)
        {

        }

        public SpcDeviceContainer(EDevice device, EDeviceType type, string key, string readBlockKey)
            : base(device, type, 0x0000, key, readBlockKey)
        {

        }

        public SpcDeviceContainer(EDevice device, EDeviceType type, int startAddress, string readBlockKey)
            : base(device, type, startAddress, string.Empty, readBlockKey)
        {
            Key = GetType().Name;
        }

        #endregion


        #region Public Methods

        public TDevice GetDevice(int index)
        {
            return this.Skip(index).FirstOrDefault() as TDevice;
        }

        #endregion


        #region Protected Methods

        protected void InitialDeviceArray(Type devType, SpcDeviceArrayContainerAttribute devArrayContainerAttribute)
        {
            var count = devArrayContainerAttribute.Count;

            for (int i = 0; i < count; i++)
            {
                var dev = (SpcDeviceBase)Activator.CreateInstance(devType);
                dev.Key = $"{Key}{i}";
                dev.Offset = i;
                if ((dev is WordDevice wordDev))
                    wordDev.Length = GetDeviceLength(devType);

                Add(dev);
            }
        } 

        #endregion

    }


    public abstract class SpcDeviceContainerBase : IEnumerable<SpcDeviceBase>
    {
        #region Private Members

        private readonly Dictionary<string, SpcDeviceBase> _Devices;

        #endregion


        #region Public Properties

        public EDevice Device { get; protected set; }

        public EDeviceType DeviceType { get; protected  set; }

        public int StartAddress { get; protected  set; }

        public string Key { get; protected  set; }

        public string ReadBlockKey { get; protected set; }

        public int Count => _Devices.Count;

        public SpcDeviceBase this[string key]
        {
            get
            {
                try
                {
                    return _Devices[key];
                }
                catch
                {
                    return null;
                }
            }
        }

        #endregion


        #region Internal Properties
        internal PlcReadWriter PlcReadWriter { get; set; }

        #endregion


        #region Constructors

        public SpcDeviceContainerBase()
        {
            _Devices = new Dictionary<string, SpcDeviceBase>();
            var devContainerType = GetType();

            var devContainerAttribute = (SpcDeviceContainerAttribute)Attribute.GetCustomAttribute(devContainerType, typeof(SpcDeviceContainerAttribute));
            if (devContainerAttribute == null)
                throw new Exception("SpcDeviceContainerAttribute Not Found");
            
            InitialDeviceContainerInfo(devContainerAttribute);
            InitialDeviceProperties(devContainerType);
        }

        public SpcDeviceContainerBase(EDevice device, EDeviceType type, int startAddress, string key, string readBlockKey)
        {
            _Devices = new Dictionary<string, SpcDeviceBase>();

            Device = device;
            DeviceType = type;
            StartAddress = startAddress;
            Key = key;
            ReadBlockKey = readBlockKey;

            InitialDeviceProperties(GetType());
        }

        #endregion


        #region Public Methods

        public void Add(SpcDeviceBase item)
        {
            lock (_Devices)
            {
                item.Device = Device;
                item.Address = (StartAddress + item.Offset);
                item.WriteToPlc += WriteToPlc;
                item.ReadFromPlc += ReadFromPlc;

                _Devices.Add(item.Key, item);
            }
        }

        public bool Remove(SpcDeviceBase item)
        {
            lock (_Devices)
            {
                var key = item.Key;
                if (_Devices.ContainsKey(key))
                {
                    item.WriteToPlc -= WriteToPlc;
                    item.ReadFromPlc -= ReadFromPlc;

                    return _Devices.Remove(key);
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Contains(SpcDeviceBase item)
        {
            return Contains(item.Key);
        }

        public bool Contains(string key)
        {
            lock (_Devices)
            {
                return _Devices.ContainsKey(key);
            }
        }

        public IEnumerator<SpcDeviceBase> GetEnumerator()
        {
            return _Devices.Values.GetEnumerator();
        }

        public virtual void PlcConnected()
        {

        }

        public virtual void BeforeRead(DeviceReadBlock devBlock)
        {

        }

        public virtual void AfterRead(DeviceReadBlock devBlock)
        {
        }

        #endregion


        #region Private Methods

        private void InitialDeviceContainerInfo(SpcDeviceContainerAttribute devContainerAttribute)
        {
            Device = devContainerAttribute.Device;
            DeviceType = devContainerAttribute.DeviceType;
            ReadBlockKey = devContainerAttribute.ReadBlockKey;
            StartAddress = devContainerAttribute.StartAddress;
            Key = devContainerAttribute.Key ?? GetType().Name;
        }

        private void InitialDeviceProperties(Type devContainerType)
        {
            var deviceProperties = devContainerType.GetProperties().Where(prop => prop.PropertyType.IsSubclassOf(typeof(SpcDeviceBase)));

            foreach (var deviceProp in deviceProperties)
            {
                var devAttribute = (SpcDeviceAttribute)Attribute.GetCustomAttribute(deviceProp, typeof(SpcDeviceAttribute));
                if (devAttribute == null)
                    continue;

                var devType = deviceProp.PropertyType;
                var dev = (SpcDeviceBase)Activator.CreateInstance(devType);

                dev.Key = deviceProp.Name;
                dev.Offset = devAttribute.Offset;
                if ((dev is WordDevice wordDev))
                    wordDev.Length = GetDeviceLength(devType, devAttribute.Length);

                deviceProp.SetValue(this, dev);
                Add(dev);
            }
        }

        protected int GetDeviceLength(Type devType, int defaultValue = 1)
        {
            int length = defaultValue;

            if (devType == typeof(WordShortDevice)
                || devType == typeof(WordUShortDevice))
            {
                length = 1;
            }
            else if (devType == typeof(WordIntDevice)
                || devType == typeof(WordUIntDevice)
                || devType == typeof(WordFloatDevice))
            {
                length = 2;
            }
            else if (devType == typeof(WordLongDevice)
                || devType == typeof(WordULongDevice)
                || devType == typeof(WordDoubleDevice))
            {
                length = 4;
            }

            return length;
        }

        #endregion


        #region Protected Methods

        protected void WriteToPlc(DeviceReadWriteInfo writeInfo)
        {
            PlcReadWriter?.WriteToPlc(writeInfo);
        }

        protected void ReadFromPlc(DeviceReadWriteInfo readInfo)
        {
            PlcReadWriter?.ReadFromPlc(readInfo);
        }

        #endregion


        #region IEnumerator

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

    }

}
