using System;

namespace IoC
{
    public interface IContainer
    {
        //TODO: implement lifecycles

        void Bind<A, B>();
        object ResolveObject(Type typeToResolve);
    }
}
