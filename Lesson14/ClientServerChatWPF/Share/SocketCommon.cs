using System.Net;
using System.Threading;

namespace Share
{
    public delegate void LogUIDeletgate(string message);

    public class SocketCommon
    {
        public LogUIDeletgate? logFunction;
        protected readonly SynchronizationContext? syncContext = SynchronizationContext.Current;

        protected virtual void Log(string message)
        {
            if(logFunction != null)
            {
                if(syncContext == SynchronizationContext.Current){
                    logFunction(message);
                }
                else
                {
                    syncContext?.Post(x => logFunction(message), null);
                }
            }
        }

        protected virtual string AddLogHeader(IPEndPoint? socket)
        {
            return "/" + socket?.Address.ToString() + ":" + socket?.Port.ToString() + "/ ";
        }
    }
}
