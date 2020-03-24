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

        private bool _IsHandshaking = false;

        private Core _Core = null;

        private BitDevice _RequestBit = null;

        private BitDevice _ReplyBit = null;

        #endregion

        public TestCommandModel(Core core)
        {
            _Core = core;
        }

        public bool OnRequestBit() => true;

        public bool OnReplyBit() => true;



        private void TimerOn()
        {
        }

        private void TimerOff()
        {
        }


        async public void RequestActionStarter()
        {
            //TODO: Lock
            if (_IsHandshaking)
                return;

            if (_RequestBit.IsOnTrigger)
            {
                _IsHandshaking = true;
                await RequestActionAsync();
                _IsHandshaking = false;
            }
        }


        async public Task RequestActionAsync()
        {
        //    // read word
        //    var alarm = _WordDevices.AlarmText;

        //    // valid check
        //    var isValid = _Core.ValidationCheck();

        //    // write word
        //    _WordDevices.AlarmType = "Reply Data";

        //    #region Common
        //    // reply bit on
        //    _ReplyBit.Value = true;

        //    // confirm req bit off
        //    var timeout = await _RequestBit.WaitBitAsync(false, 2000);  // T4

        //    _ReplyBit.Value = false;
        //    if (timeout)
        //    {
        //        OnTimeOut();
        //    }             
        //    #endregion
        }

        async public Task ReportActionAsync()
        {
            //// write word
            //_WordDevices.AlarmType = "Report Data";

            //#region Common
            //await Task.Delay(1000); // Tn Delay

            //// req bit on
            //_RequestBit.Value = true;

            //// confirm rep bit on
            //var timeout = await _ReplyBit.WaitBitAsync(true, 2000);   // T1

            //// req bit off
            //_RequestBit.Value = false;

            //if (timeout)
            //{
            //    OnTimeOut();
            //    return;
            //}

            //timeout = await _ReplyBit.WaitBitAsync(false, 2000);  // T2

            //if (timeout)
            //{
            //    OnTimeOut();
            //} 
            //#endregion
        }


        protected virtual void OnTimeOut()
        {

        }

    }
}
