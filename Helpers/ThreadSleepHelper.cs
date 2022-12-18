using System.Threading;

namespace ParaBankPractice.Helpers
{
    public static class ThreadSleepHelper
    {
        public static void Sleep(int millisecondsTimeout)
        {
            Thread.Sleep(millisecondsTimeout);
        }
    }
}