using System;
using System.Collections.Generic;
using System.Linq;

namespace IoC
{
    public class IoC : IContainer
    {
        private readonly List<RegisteredObject> registeredObjects = new List<RegisteredObject>();

        public void Bind<A, B>()
        {
            registeredObjects.Add(new RegisteredObject(typeof(A), typeof(B)));
        }

        public object ResolveObject(Type typeToResolve)
        {
            var registeredObject = registeredObjects.FirstOrDefault(o => o.TypeToResolve == typeToResolve);
            if(registeredObject == null)
            {
                throw new TypeNotRegisteredException(string.Format("The type {0} has not been registered", typeToResolve.Name));
            }
            return GetInstance(registeredObject);
        }

        private object GetInstance(RegisteredObject registeredObject)
        {
            var parameters = ResolveConstructorParameters(registeredObject);
            registeredObject.CreateInstance((Type[])parameters.ToArray());

            return registeredObject;
        }

        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject registeredObject)
        {
            var constructorInfo = registeredObject.ConcreteType.GetConstructors().First();
            foreach (var parameter in constructorInfo.GetParameters())
            {
                yield return ResolveObject(parameter.ParameterType);
            }
        }
    }
}
