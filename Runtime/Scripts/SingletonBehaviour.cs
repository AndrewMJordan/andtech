/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using System.Diagnostics;
using UnityEngine;

namespace Andtech
{


    /// <summary>
    /// Base class for defining singleton MonoBehaviours.
    /// </summary>
    /// <typeparam name="T">The type of the singleton instance.</typeparam>
    [DebuggerStepThrough]
    public abstract class SingletonBehaviour : MonoBehaviour
    {

        /// <summary>
        /// Initializes the singleton environment.
        /// </summary>
        /// <remarks>Note: <see cref="RuntimeInitializeOnLoadMethodAttribute"/> may not work on generic <see cref="MonoBehaviour"/>s.</remarks>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        internal static void InitializeOnLoad()
        {
            InitializedOnLoad?.Invoke();
        }

        #region EVENT
        /// <summary>
        /// Use this to receive <see cref="RuntimeInitializeOnLoadMethodAttribute"/> callbacks.
        /// </summary>
        public static event Action InitializedOnLoad;
        #endregion
    }

    public abstract partial class SingletonBehaviour<T> : SingletonBehaviour where T : SingletonBehaviour<T>
    {
        /// <summary>
        /// There exists a singleton instance.
        /// </summary>
        public static bool HasInstance => slot.HasValue;
        /// <summary>
        /// The current singleton instance.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (HasInstance)
                {
                    return slot.Value;
                }

                throw new SingletonReferenceException(typeof(T));
            }
            protected set => slot.Value = value;
        }
        /// <summary>
        /// Is this the current singleton instance?
        /// </summary>
        public bool IsSingletonInstance
        {
            get
            {
                if (!slot.HasValue)
                {
                    return false;
                }

                return ReferenceEquals(this, Instance);
            }
        }

        private static readonly Slot<T> slot = new Slot<T>();

        static SingletonBehaviour()
        {
            slot.OnValueChanged += (oldValue, newValue) =>
            {
                if (oldValue != null)
                {
                    Decommissioned?.Invoke(null, new SingletonEventArgs((T)oldValue));
                }
                if (newValue != null)
                {
                    Commissioned?.Invoke(null, new SingletonEventArgs((T)newValue));
                }
            };
        }

        protected void SetInstance(T instance)
        {
            if (!HasInstance)
            {
                Instance = instance;
            }
        }

        protected void ClearInstance(T instance)
        {
            if (instance.IsSingletonInstance)
            {
                Instance = null;
            }
        }

        #region MONOBEHAVIOUR
        protected virtual void OnEnable() => SetInstance((T)this);

        protected virtual void OnDisable() => ClearInstance((T)this);
        #endregion

        #region TYPE
        public class SingletonEventArgs : EventArgs
        {
            public readonly T Instance;

            public SingletonEventArgs(T instance) => Instance = instance;
        }
        #endregion

        #region EVENT
        /// <summary>
        /// A singleton instance became newly active.
        /// </summary>
        public static event EventHandler<SingletonEventArgs> Commissioned;
        /// <summary>
        /// The former singleton instance became inactive.
        /// </summary>
        public static event EventHandler<SingletonEventArgs> Decommissioned;
        #endregion
    }
}
