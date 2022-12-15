using System.Threading;

namespace ParaBankPractice.Helpers
{
    public class ThreadSleepHelper
    {
        public static void Sleep(int millisecondsTimeout)
        {
            Thread.Sleep(millisecondsTimeout);
        }
    }
}