/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

namespace Andtech
{

    /// <summary>
    /// Template for registering to a subject safely.
    /// </summary>
    /// <typeparam name="T">The type of the subject.</typeparam>
    public interface IObserver<T>
    {

        /// <summary>
        /// When the subject allows it, the observer will be notified of this registration callback.
        /// </summary>
        /// <param name="instance">The subject instance.</param>
        void OnRegister(T instance);

        /// <summary>
        /// When the subject allows it, the observer will be notified of this unregistration callback.
        /// </summary>
        /// <param name="instance">The subject instance.</param>
        void OnUnregister(T instance);
    }
}
