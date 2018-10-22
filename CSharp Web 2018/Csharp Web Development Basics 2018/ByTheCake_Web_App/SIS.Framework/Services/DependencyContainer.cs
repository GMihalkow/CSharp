namespace SIS.Framework.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using SIS.Framework.Services.Contracts;

    public class DependencyContainer : IDependencyContainer
    {
        private readonly IDictionary<Type, Type> dependencyContainer;

        public DependencyContainer()
        {
            this.dependencyContainer = new Dictionary<Type, Type>();
        }

        private Type this[Type key]
            => this.dependencyContainer.ContainsKey(key) ? this.dependencyContainer[key] : null;

        public object CreateInstance(Type type)
        {
            //Getting type
            Type instanceType = this[type] ?? type;

            //Checking if type can be instantiated
            if (instanceType.IsInterface || instanceType.IsAbstract)
            {
                throw new InvalidOperationException($"Type {instanceType.FullName} cannot be instantiated.");
            }

            //Getting constructor with least parameters
            ConstructorInfo constructor =
                instanceType
                .GetConstructors()
                .OrderBy(x => x.GetParameters().Length)
                .First();

            //Getting parameters
            ParameterInfo[] constructorParameters = constructor.GetParameters();
            //Creating an array of objects
            object[] constructorParameterObjects = new object[constructorParameters.Length];

            //Filling our array up with the parameter types of the constructor
            for (int index = 0; index < constructorParameters.Length; index++)
            {
                constructorParameterObjects[index] = this.CreateInstance(constructorParameters[index].ParameterType);
            }

            //Returning the array with the parameter types
            return constructor.Invoke(constructorParameterObjects);
        }

        public void RegisterDependency<TSource, TDestination>()
        {
            this.dependencyContainer[typeof(TSource)] = typeof(TDestination);
        }

        public T CreateInstance<T>()
            => (T)this.CreateInstance(typeof(T));
    }
}