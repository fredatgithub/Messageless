using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace Messageless
{
    [Serializable]
    public class InvocationMessage : IMessage
    {
        public MethodInfo Method { get; set; }
        public object[] Arguments { get; set; }

        public InvocationMessage(IInvocation invocation)
            : this(invocation.Method, invocation.Arguments)
        {
        }

        public InvocationMessage(MethodInfo method, object[] arguments)
        {
            Method = method;
            Arguments = arguments;
        }
    }
}