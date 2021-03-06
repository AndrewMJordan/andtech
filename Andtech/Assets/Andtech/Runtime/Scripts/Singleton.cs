﻿using System.Diagnostics;

namespace Andtech
{

    /// <summary>
    /// Base class for defining singletons.
    /// </summary>
    /// <typeparam name="T">The type of the singleton instance.</typeparam>
    [DebuggerStepThrough]
    public abstract class Singleton<T> where T : Singleton<T>
    {
        public static T Instance
        {
            get
            {
                if (!HasInstance)
                {
                    throw new SingletonReferenceException(typeof(T));
                }

                return instance;
            }
            set => instance = value;
        }
        public static bool HasInstance => !(instance is null);

        private static T instance;
    }
}
