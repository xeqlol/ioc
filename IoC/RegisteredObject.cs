using System;

namespace IoC
{
    class RegisteredObject : IRegisteredObject
    {
        public Type TypeToResolve { get; set; }
        public Type ConcreteType { get; set; }

        private object instance;

        public RegisteredObject(Type typeToResolve, Type concreteType)
        {
            TypeToResolve = typeToResolve;
            ConcreteType = concreteType;
        }

        // singleton
        public object CreateInstance(Type[] parameters)
        {
            if (instance == null)
                instance = ConcreteType.GetConstructor(parameters);

            return instance;
        }
    }
}
