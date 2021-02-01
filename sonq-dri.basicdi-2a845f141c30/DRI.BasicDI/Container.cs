using System;
using System.Linq;
using System.Collections.Generic;
using DRI.BasicDI.Exceptions;

namespace DRI.BasicDI
{
    public sealed class Container
    {
        private readonly Dictionary<Type, object> registeredTypes = new Dictionary<Type, object>();
        private List<Type> dependencies = new List<Type>();
        private Type initialType;
        public void Register<T>()
        {
            if (registeredTypes.ContainsKey(typeof(T)))
            {
                throw new AlreadyRegisteredException();
            }
            registeredTypes.Add(typeof(T), Register(typeof(T)));
        }

        private object Register(Type type, bool isDependency = false)
        {
            if (!isDependency)
            {
                initialType = type;
            }

            var constructor = type.GetConstructors().OrderByDescending(a => a.GetParameters().Length).First();
            dependencies.AddRange(constructor.GetParameters().Select(a => a.ParameterType));
            if (dependencies.Contains(initialType))
            {
                throw new CircularDependencyException();
            }

            var args = constructor.GetParameters().Select(param => Register(param.ParameterType, true)).ToArray();
            return Activator.CreateInstance(type, args);
        }

        public int Registrations()
        {
            throw new NotImplementedException();
        }

        public T GetInstance<T>()
        {
            if (registeredTypes.ContainsKey(typeof(T)))
            {
                return (T)registeredTypes[typeof(T)];
            }
            else
            {
                throw new UnregisteredDependencyException();
            }
        }
    }
}