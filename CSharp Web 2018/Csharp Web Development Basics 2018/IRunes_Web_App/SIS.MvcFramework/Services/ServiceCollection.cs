namespace SIS.MvcFramework.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SIS.MvcFramework.Services.Contracts;

    public class ServiceCollection : IServiceCollection
    {
        private readonly IDictionary<Type, Type> dependencyContainer;

        private readonly IDictionary<Type, Func<object>> dependencyContainerWithFunc;

        public ServiceCollection()
        {
            dependencyContainer = new Dictionary<Type, Type>();
            dependencyContainerWithFunc = new Dictionary<Type, Func<object>>();
        }

        public void AddService<TSource, TDestination>()
        {
            this.dependencyContainer[typeof(TSource)] = typeof(TDestination);
        }

        public void AddService<T>(Func<T> p)
        {
            this.dependencyContainerWithFunc.Add(typeof(T), () => p());
        }

        public T CreateInstance<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }

        public object CreateInstance(Type type)
        {
            if (this.dependencyContainer.ContainsKey(type))
            {
                type = this.dependencyContainer[type];
            }

            if (type.IsInterface || type.IsAbstract)
            {
                throw new Exception($"Type {type.FullName} cannot be instantiated.");
            }

            var constructor = type.GetConstructors().First();
            var constructorParameters = constructor.GetParameters();
            var constructorParameterObjects = new List<object>();
            foreach (var constructorParameter in constructorParameters)
            {
                var parameterObject = this.CreateInstance(
                    constructorParameter.ParameterType);
                constructorParameterObjects.Add(parameterObject);
            }

            var obj = constructor.Invoke(constructorParameterObjects.ToArray());
            return obj;
        }
    }
}