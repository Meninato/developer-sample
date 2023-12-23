using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DeveloperSample.Container
{
    public class Container
    {
        private Dictionary<Type, Func<object>> _container = new Dictionary<Type, Func<object>>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            _container.Add(interfaceType, () => this.GetInstance(implementationType));
        }

        public T Get<T>() 
        {
            return (T)this.GetInstance(typeof(T));
        }

        private object GetInstance(Type type)
        {
            if (_container.TryGetValue(type, out Func<object> fac)) return fac();
            else if (!type.IsAbstract) return this.CreateInstance(type);
            throw new InvalidOperationException("No registration for " + type);
        }

        private object CreateInstance(Type implementationType)
        {
            var ctor = implementationType.GetConstructors().Single();
            var paramTypes = ctor.GetParameters().Select(p => p.ParameterType);
            var dependencies = paramTypes.Select(GetInstance).ToArray();
            return Activator.CreateInstance(implementationType, dependencies);
        }
    }
}