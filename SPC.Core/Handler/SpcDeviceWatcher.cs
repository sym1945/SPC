using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SPC.Core
{
    public class SpcDeviceWatcher : ICollection<DeviceReadBlock>
    {
        #region Constant

        private const int WATCH_DELAY = 100;

        #endregion


        #region Private Members

        private bool _IsRunning = false;
        private Thread _RunningThread = null;
        private readonly List<DeviceReadBlock> _ReadBlocks = new List<DeviceReadBlock>();

        #endregion


        #region Internal Properties

        internal SpcCommunication Comm { get; set; }

        #endregion


        #region Public Properties

        public bool IsRunning => _IsRunning;

        public bool IsConnected => Comm?.IsOpen ?? false;

        public int Count => _ReadBlocks.Count;

        public bool IsReadOnly => true;

        #endregion


        #region Events

        public event Action BeforeRead;
        public event Action AfterRead;
        private void OnBeforeRead()
        {
            foreach (var readBlock in _ReadBlocks)
            {
                readBlock.OnBeforeRead();
            }
            BeforeRead?.Invoke();
        }
        private void OnAfterRead()
        {
            foreach (var readBlock in _ReadBlocks)
            {
                readBlock.OnAfterRead();
            }
            AfterRead?.Invoke();
        }

        #endregion


        #region Constructor

        public SpcDeviceWatcher()
        {
        }

        #endregion


        #region Public Methods


        public bool Start()
        {
            if (!IsConnected)
                Comm?.Open();

            if (_IsRunning
                || _RunningThread != null
                || !IsConnected)
                return false;

            _IsRunning = true;
            _RunningThread = new Thread(() =>
            {
                //TODO: logging Thread Start

                while (_IsRunning)
                {
                    Thread.Sleep(WATCH_DELAY);

                    try
                    {
                        OnBeforeRead();

                        foreach (var block in _ReadBlocks)
                        {
                            var result = Comm.BlockRead(block.Device, block.StartAddress, block.Size, ref block.Buffer);
                            if (result == 0)
                            {
                                //TODO: Update Device Map
                            }
                            else
                            {
                                //TODO: logging Block Read Fail
                            }
                        }

                        OnAfterRead();
                    }
                    catch (Exception ex)
                    {
                        //TODO: logging Error
                    }
                }

                //TODO: logging Thread End
            });
            _RunningThread.IsBackground = true;
            _RunningThread.Start();

            return true;
        }

        public void Stop()
        {
            if (_IsRunning && _RunningThread != null)
            {
                _IsRunning = false;
                _RunningThread.Join();
                _RunningThread = null;
            }

            Comm?.Close();
        }

        public DeviceReadBlock GetReadBlock(string key)
        {
            return _ReadBlocks.FirstOrDefault(block => block.Key == key);
        }


        public void Add(DeviceReadBlock item)
        {
            lock (_ReadBlocks)
            {
                _ReadBlocks.Add(item);
            }
        }

        public bool Remove(DeviceReadBlock item)
        {
            lock (_ReadBlocks)
            {
                if (_ReadBlocks.Contains(item))
                {
                    return _ReadBlocks.Remove(item);
                }
                else
                {
                    return false;
                }
            }
        }

        public void Clear()
        {
            lock (_ReadBlocks)
            {
                _ReadBlocks.Clear();
            }
        }

        public bool Contains(DeviceReadBlock item)
        {
            lock (_ReadBlocks)
            {
                return _ReadBlocks.Contains(item);
            }
        }

        public void CopyTo(DeviceReadBlock[] array, int arrayIndex)
        {
            lock (_ReadBlocks)
            {
                _ReadBlocks.CopyTo(array, arrayIndex);
            }
        }



        public IEnumerator<DeviceReadBlock> GetEnumerator()
        {
            return _ReadBlocks.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

    }
}
