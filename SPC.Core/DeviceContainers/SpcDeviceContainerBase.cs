using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SPC.Core
{
    public abstract class SpcDeviceContainer<TDevice> : SpcDeviceContainerBase
        where TDevice : SpcDeviceBase
    {
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

        public TDevice GetDevice(int index)
        {
            return this.Skip(index).Take(1) as TDevice;
        }

    }


    public abstract class SpcDeviceContainerBase : IEnumerable<SpcDeviceBase>
    {
        #region Private Members

        private readonly Dictionary<string, SpcDeviceBase> _Devices;

        #endregion


        #region Public Properties

        public EDevice Device { get; set; }

        public EDeviceType DeviceType { get; set; }

        public int StartAddress { get; set; }

        public string Key { get; set; }

        public string ReadBlockKey { get; set; }

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
            if (devContainerAttribute != null)
            {
                InitialDeviceContainerInfo(devContainerAttribute);
                InitialDeviceProperties(devContainerType);
            }
           
            var devArrayContainerAttribute = (SpcDeviceArrayContainerAttribute)Attribute.GetCustomAttribute(devContainerType, typeof(SpcDeviceArrayContainerAttribute));
            if (devArrayContainerAttribute != null)
            {
                InitialDeviceArray(devContainerType, devArrayContainerAttribute);
            }
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
            StartAddress = devContainerAttribute.StartAddress;
            Key = devContainerAttribute.Key;
            ReadBlockKey = devContainerAttribute.ReadBlockKey;
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

        private void InitialDeviceArray(Type devContainerType, SpcDeviceArrayContainerAttribute devArrayContainerAttribute)
        {
            var count = devArrayContainerAttribute.Count;

            int length = 0;
            for (int i = 0; i < count; i++)
            {
                var devType = devContainerType;
                var dev = (SpcDeviceBase)Activator.CreateInstance(devType);
                dev.Key = $"{Key}{i}";
                dev.Offset = i;
                if ((dev is WordDevice wordDev))
                    wordDev.Length = length;

                Add(dev);
            }
        }

        private int GetDeviceLength(Type devType, int defaultValue = 1)
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


    [SpcDeviceArrayContainer(EDevice.W, EDeviceType.Word, 0x0000, 10, "ARRAY_WRODS", "2")]
    public class WordDeviceArrayContainer2 : SpcDeviceContainer<WordDevice>
    {
    }


    [SpcDeviceContainer(EDevice.W, EDeviceType.Word, 0x0010, "SAMPLE_WORDS", "1")]
    public class SampleDeviceContainer : SpcDeviceContainer<WordDevice>
    {
        [SpcDevice(0x0000, length: 4)]
        public WordStringDevice StringDev { get; private set; }

        [SpcDevice(0x0004)]
        public WordIntDevice IntDev { get; private set; }
    }


}
