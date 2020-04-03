using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public abstract class PlcCommandActionBase
    {
        protected DeviceManager DevManager = SPCContainer.GetSPC().DeviceManager;

        internal PlcCommand PlcCommand { get; set; }

        internal abstract void Initialize();

        public abstract bool CanExecute();

        public abstract void Execute();
    }
}


//public async void Call2()
//{
//    if (_IsRun)
//        return;
//    _IsRun = true;

//    BeforeTriggerBitOn();

//    await Task.Delay(1000); // Tn Delay

//    _RequestBit.WriteValue(true);

//    var timeout = await _ReplyBit.WaitBitAsync(true, 2000); // T1

//    _RequestBit.WriteValue(false);

//    if (timeout)
//    {
//        TimeOutReplyBitOn();
//        _IsRun = false;
//        return;
//    }

//    timeout = await _ReplyBit.WaitBitAsync(false, 2000); // T2

//    if (timeout)
//    {
//        TimeOutReplyBitOff();
//    }

//    _IsRun = false;
//}

//public virtual void BeforeTriggerBitOn()
//{

//}

//public virtual void AfterTriggerBitOn()
//{

//}

//public virtual void AfterTriggerBitOff()
//{

//}

//public virtual void TimeOutTriggerBitOff()
//{

//}

//public virtual void TimeOutReplyBitOn()
//{

//}

//public virtual void TimeOutReplyBitOff()
//{

//}

//protected virtual void OnTimeOut()
//{

//}