using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace SPC.Core
{
    [Serializable]
    public class Melsec : PlcComm
    {
        #region Private Members
        private int _nPath = 0;
        private short _StationNo = 255;
        private short _Mode = 0;
        private eChannel _Channel = eChannel.CCLINK_IE_CTRLER_1;
        #endregion


        #region Public Properties
        public eChannel Channel
        {
            get => _Channel;
            set
            {
                if (_Channel == value)
                    return;
                _Channel = value;
                OnPropertyChanged(nameof(Channel));
            }
        }
        public short StationNo
        {
            get => _StationNo;
            set
            {
                if (_StationNo == value)
                    return;
                _StationNo = value;
                OnPropertyChanged(nameof(StationNo));
            }
        }
        
        #endregion


        #region Constructor
        public Melsec()
        {
        }
        public Melsec(eChannel _channel, short _station) : this()
        {
            _Channel = _channel;
            _StationNo = _station;
        }
        #endregion


        #region Public Methods
        public override short Open()
        {
            if (IsOpen)
                return 0;

            var ret = MelsecFunction.mdOpen((short)_Channel, _Mode, ref _nPath);

            if (ret == 0)
                IsOpen = true;

            return ret;
        }
        public override short Close()
        {
            var ret = MelsecFunction.mdClose(_nPath);

            if (ret == 0)
                IsOpen = false;

            return ret;
        }

        public override short BlockWrite(eDevice device, short deviceNo, short size, ref short[] buf)
        {
            size = (short)(size * 2);
            var ret = MelsecFunction.mdSend(_nPath, _StationNo, (short)device, deviceNo, ref size, ref buf[0]);
            return ret;
        }

        public override short BlockRead(eDevice device, short deviceNo, short size, ref short[] buf)
        {
            size = (short)(size * 2);
            var ret = MelsecFunction.mdReceive(_nPath, _StationNo, (short)device, deviceNo, ref size, ref buf[0]);
            return ret;
        }

        public override short SetBit(eDevice device, short devno, bool set)
        {
            return set
                ? MelsecFunction.mdDevSet(_nPath, _StationNo, (short)device, devno)
                : MelsecFunction.mdDevRst(_nPath, _StationNo, (short)device, devno);
        } 
        #endregion
    }


    public static class MelsecFunction
    {
        readonly static object Locker = new object();

        public static short mdOpen(short Chan, short Mode, ref int Path)
        {
            lock (Locker)
                return SafeNativeMethods.mdOpen(Chan, Mode, ref Path);
        }
        public static short mdClose(int Path)
        {
            lock (Locker)
                return SafeNativeMethods.mdClose(Path);
        }
        public static short mdSend(int Path, short Stno, short Devtyp, short devno, ref short size, ref short buf)
        {
            lock (Locker)
                return SafeNativeMethods.mdSend(Path, Stno, Devtyp, devno, ref size, ref buf);
        }
        public static short mdReceive(int Path, short Stno, short Devtyp, short devno, ref short size, ref short buf)
        {
            lock (Locker)
                return SafeNativeMethods.mdReceive(Path, Stno, Devtyp, devno, ref size, ref buf);
        }
        public static short mdDevSet(int Path, short Stno, short Devtyp, short devno)
        {
            lock (Locker)
                return SafeNativeMethods.mdDevSet(Path, Stno, Devtyp, devno);
        }
        public static short mdDevRst(int Path, short Stno, short Devtyp, short devno)
        {
            lock (Locker)
                return SafeNativeMethods.mdDevRst(Path, Stno, Devtyp, devno);
        }
        public static short mdRandW(int Path, short Stno, ref short dev, ref short buf, short bufsiz)
        {
            lock (Locker)
                return SafeNativeMethods.mdRandW(Path, Stno, ref dev, ref buf, bufsiz);
        }
        public static short mdRandR(int Path, short Stno, ref short dev, ref short buf, short bufsiz)
        {
            lock (Locker)
                return SafeNativeMethods.mdRandR(Path, Stno, ref dev, ref buf, bufsiz);
        }
        public static short mdControl(int Path, short Stno, short buf)
        {
            lock (Locker)
                return SafeNativeMethods.mdControl(Path, Stno, buf);
        }
        public static short mdTypeRead(int Path, short Stno, ref short buf)
        {
            lock (Locker)
                return SafeNativeMethods.mdTypeRead(Path, Stno, ref buf);
        }
        public static short mdBdLedRead(int Path, ref short buf)
        {
            lock (Locker)
                return SafeNativeMethods.mdBdLedRead(Path, ref buf);
        }
        public static short mdBdModRead(int Path, ref short Mode)
        {
            lock (Locker)
                return SafeNativeMethods.mdBdModRead(Path, ref Mode);
        }
        public static short mdBdModSet(int Path, ref short Mode)
        {
            lock (Locker)
                return SafeNativeMethods.mdBdModSet(Path, ref Mode);
        }
        public static short mdBdRst(int Path)
        {
            lock (Locker)
                return SafeNativeMethods.mdBdRst(Path);
        }
        public static short mdBdSwRead(int Path, ref short buf)
        {
            lock (Locker)
                return SafeNativeMethods.mdBdSwRead(Path, ref buf);
        }
        public static short mdBdVerRead(int Path, ref short buf)
        {
            lock (Locker)
                return SafeNativeMethods.mdBdVerRead(Path, ref buf);
        }
        public static short mdInit(int Path)
        {
            lock (Locker)
                return SafeNativeMethods.mdInit(Path);
        }
        public static short mdWaitBdEvent(int Path, ref short eventno, int timeout, ref short signaledno, ref short details)
        {
            lock (Locker)
                return SafeNativeMethods.mdWaitBdEvent(Path, ref eventno, timeout, ref signaledno, ref details);
        }
        public static int mdSendEx(int Path, int Netno, int Stno, int Devtyp, int devno, ref int size, ref short buf)
        {
            lock (Locker)
                return SafeNativeMethods.mdSendEx(Path, Netno, Stno, Devtyp, devno, ref size, ref buf);
        }
        public static int mdReceiveEx(int Path, int Netno, int Stno, int Devtyp, int devno, ref int size, ref short buf)
        {
            lock (Locker)
                return SafeNativeMethods.mdReceiveEx(Path, Netno, Stno, Devtyp, devno, ref size, ref buf);
        }
        public static int mdDevSetEx(int Path, int Netno, int Stno, int Devtyp, int devno)
        {
            lock (Locker)
                return SafeNativeMethods.mdDevSetEx(Path, Netno, Stno, Devtyp, devno);
        }
        public static int mdDevRstEx(int Path, int Netno, int Stno, int Devtyp, int devno)
        {
            lock (Locker)
                return SafeNativeMethods.mdDevRstEx(Path, Netno, Stno, Devtyp, devno);
        }
        public static int mdRandWEx(int Path, int Netno, int Stno, ref int dev, ref short buf, int bufsiz)
        {
            lock (Locker)
                return SafeNativeMethods.mdRandWEx(Path, Netno, Stno, ref dev, ref buf, bufsiz);
        }
        public static int mdRandREx(int Path, int Netno, int Stno, ref int dev, ref short buf, int bufsiz)
        {
            lock (Locker)
                return SafeNativeMethods.mdRandREx(Path, Netno, Stno, ref dev, ref buf, bufsiz);
        }
    }

}
