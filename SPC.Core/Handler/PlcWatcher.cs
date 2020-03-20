using System;
using System.Collections.Generic;
using System.Threading;

namespace SPC.Core
{
    public class PlcWatcher
    {
        #region Constant
        private const int WATCH_DELAY = 100; 
        #endregion

        #region Private Members
        private bool _IsRunning = false;
        private PlcComm _Comm = null;
        private Thread _RunningThread = null;
        private List<PlcReadBlock> _ReadBlocks = new List<PlcReadBlock>();
        #endregion


        #region Public Properties
        public bool IsRunning => _IsRunning;
        #endregion


        #region Events
        public event Action PlcConnected;
        public event Action<IReadOnlyList<PlcReadBlock>> BeginRead;
        public event Action<IReadOnlyList<PlcReadBlock>> EndRead; 
        #endregion


        #region Constructor
        public PlcWatcher()
        {
            _Comm = new Melsec();
        }

        public PlcWatcher(PlcComm comm)
        {
            _Comm = comm;
        }
        #endregion


        #region Public Methods
        public void Start()
        {
            if (_IsRunning || _RunningThread != null)
                return;

            _IsRunning = true;
            _RunningThread = new Thread(() =>
            {
                //TODO: logging Thread Start

                while (_IsRunning)
                {
                    Thread.Sleep(WATCH_DELAY);

                    try
                    {
                        BeginRead?.Invoke(_ReadBlocks);

                        foreach (var block in _ReadBlocks)
                        {
                            var result = _Comm.BlockRead(block.Device, block.StartAddress, block.Size, ref block.Buffer);
                            if (result == 0)
                            {
                                //TODO: Update Device Map
                            }
                            else
                            {
                                //TODO: logging Block Read Fail
                            }
                        }

                        EndRead?.Invoke(_ReadBlocks);
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
        }

        public void Stop()
        {
            if (_IsRunning && _RunningThread != null)
            {
                _IsRunning = false;
                _RunningThread.Join();
                _RunningThread = null;
            }
        } 
        #endregion

    }
}
