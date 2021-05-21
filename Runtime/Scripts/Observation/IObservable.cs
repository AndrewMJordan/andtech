/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

namespace Andtech
{

	public interface IObservable<T>
	{

		void Register(IObserver<T> observer);

		void Unregister(IObserver<T> observer);
	}
}
