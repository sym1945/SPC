using System.Threading.Tasks;

namespace SPC.Core
{
    public static class TaskExtension
    {
        public static void DoNotAwait(this Task task)
        {
            
        }

        public static async Task<bool> WaitAsync(this Task task, int millisecond)
        {
            bool ret = false;

            await Task.Run(() =>
            {
                ret= task.Wait(millisecond);
            });

            return ret;
        }

    }
}