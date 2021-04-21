﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DependenciInjectionWorkoshop.DI.Containers
{
    public abstract class AbstractContainer : IContainer
    {

        private Dictionary<Type, Type> mappings;
        private Dictionary<Type, KeyValuePair<Type, Func<object>>> mappingsWhitCustomCreation;

        public AbstractContainer()
        {
            mappings = new Dictionary<Type, Type>();
            mappingsWhitCustomCreation = new Dictionary<Type, KeyValuePair<Type, Func<object>>>();
        }

        public abstract void ConfigureService();

        public void CreateMapping<TInterfaceType, TImplementationType>()
        {
            CheckIsAssinableFrom<TInterfaceType, TImplementationType>();

            mappings[typeof(TInterfaceType)] = typeof(TImplementationType);

        }

        public void CreateMapping<TInterfaceType, TImplementationType> (Func<object> creationFunc)
        {
            CheckIsAssinableFrom<TInterfaceType, TImplementationType>();

            mappingsWhitCustomCreation[typeof(TInterfaceType)] = new KeyValuePair<Type, Func<object>>
                (typeof(TImplementationType), creationFunc);
        }

        public Type GetMapping(Type interfaceType)
        {
            if (!mappings.ContainsKey(interfaceType))
            {
                return null;
            }
            return mappings[interfaceType];
        }

        public KeyValuePair<Type, Func<object>> GetCustomMapping(Type interfaceType)
        {
            return mappingsWhitCustomCreation[interfaceType];
        }

        private void CheckIsAssinableFrom<TInterfaceType, TImplementationType>() 
        {
            if (!typeof(TInterfaceType).IsAssignableFrom(typeof(TImplementationType)))
            {
                throw new ArgumentException($"{typeof(TInterfaceType)} is not assignle from {typeof(TImplementationType).Name}");
            }           
        }
    }
}
