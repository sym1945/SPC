using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class TestCommandModel
    {
        #region Private Members

        private BitDevice _RequestBit = null;

        private BitDevice _ReplyBit = null;

        private bool _IsRun = false;

        #endregion


        public async void Call()
        {
            if (_IsRun)
                return;
            if (!_RequestBit.IsOnTrigger)
                return;

            _IsRun = true;

            AfterTriggerBitOn();

            _ReplyBit.WriteValue(true);

            var timeout = await _RequestBit.WaitBitAsync(false, 2000); // T4

            _ReplyBit.WriteValue(false);

            if (timeout)
                TimeOutTriggerBitOff();
            else
                AfterTriggerBitOff();
            

            _IsRun = false;
        }

        public async void Call2()
        {
            if (_IsRun)
                return;
            _IsRun = true;

            BeforeTriggerBitOn();

            await Task.Delay(1000); // Tn Delay

            _RequestBit.WriteValue(true);

            var timeout = await _ReplyBit.WaitBitAsync(true, 2000); // T1

            _RequestBit.WriteValue(false);

            if (timeout)
            {
                TimeOutReplyBitOn();
                _IsRun = false;
                return;
            }

            timeout = await _ReplyBit.WaitBitAsync(false, 2000); // T2

            if (timeout)
            {
                TimeOutReplyBitOff();
            }

            _IsRun = false;
        }

        public virtual void BeforeTriggerBitOn()
        {

        }

        public virtual void AfterTriggerBitOn()
        {
            
        }

        public virtual void AfterTriggerBitOff()
        {

        }

        public virtual void TimeOutTriggerBitOff()
        {
            
        }

        public virtual void TimeOutReplyBitOn()
        {

        }

        public virtual void TimeOutReplyBitOff()
        {

        }

        protected virtual void OnTimeOut()
        {

        }

    }
}
