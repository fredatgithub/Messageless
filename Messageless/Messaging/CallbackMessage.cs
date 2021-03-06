using System;
using System.Reflection;
using Messageless.Transport;

namespace Messageless.Messaging
{
    [Serializable]
    public class CallbackMessage : IMessage, ITransportAware
    {
        public Context Context { get; set; }
        public Type DelegateType { get; set; }
        public object[] Arguments { get; set; }

        public MethodInfo Method
        {
            get { return DelegateType.GetMethod("Invoke"); }
        }

        public CallbackMessage(Context context, Type delegateType, object[] arguments)
        {
            Context = context;
            DelegateType = delegateType;
            Arguments = arguments ?? new object[Method.GetParameters().Length];
        }

        public void SetTransportMessage(TransportMessage transportMessage)
        {
            Context.SenderPath = transportMessage.SenderPath;
        }
    }
}