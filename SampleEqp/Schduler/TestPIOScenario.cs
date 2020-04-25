using SPC.Core;
using System.Threading.Tasks;

namespace SampleEqp
{
    public enum ScenarioStep
    {
        WaitStartSignal,
        MoveStart,
        WaitComplete,
        Complete,
        Done
    }

    public class TestPIOScenario
    {
        private readonly object _Locker = new object();

        private bool _IsRunning;

        private ScenarioStep _Step;
        readonly BitDeviceContainer EqpBits;
        readonly BitDeviceContainer IdxBits;

        public bool Start()
        {
            lock (_Locker)
            {
                if (_IsRunning)
                    return false;

                _IsRunning = true;
            }

            RunScenarioAsync().DoNotAwait();

            return true;
        }


        private async Task RunScenarioAsync()
        {
            IdxBits["SendAble"].WriteValue(true);

            _Step = ScenarioStep.WaitStartSignal;

            while (_Step != ScenarioStep.Done)
            {
                switch (_Step)
                {
                    case ScenarioStep.WaitStartSignal:
                        {
                            if (await WaitRecvStartAsync())
                                _Step = ScenarioStep.MoveStart;

                            break;
                        }
                    case ScenarioStep.MoveStart:
                        {
                            await StartMoveThenComplete();
                            _Step = ScenarioStep.WaitComplete;

                            break;
                        }
                    case ScenarioStep.WaitComplete:
                        {
                            if (await WaitRecvCompleteAsync())
                                _Step = ScenarioStep.Complete;

                            break;
                        }
                    case ScenarioStep.Complete:
                        {
                            ClearSignal();
                            _Step = ScenarioStep.Done;

                            break;
                        }
                }
            }

            lock (_Locker)
            {
                _IsRunning = false;
            }
        }


        public async Task<bool> WaitRecvStartAsync()
        {
            var isChanged =  await EqpBits["RecvStart"].WaitBitAsync(true, 3000);
            if (!isChanged)
            {
                // On Time out!!
            }

            return isChanged;
        }

        public async Task StartMoveThenComplete()
        {
            IdxBits["SendStart"].WriteValue(true);

            // Run.....
            await Task.Delay(3000);

            IdxBits["SendComplete"].WriteValue(true);
        }

        public async Task<bool> WaitRecvCompleteAsync()
        {
            var isChanged = await EqpBits["RecvComplete"].WaitBitAsync(true, 3000);
            if (!isChanged)
            {
                // On Time out!!
            }

            return isChanged;
        }

        public void ClearSignal()
        {
            IdxBits["SendAble"].WriteValue(false);
            IdxBits["SendStart"].WriteValue(false);
            IdxBits["SendComplete"].WriteValue(false);
        }


    }
}