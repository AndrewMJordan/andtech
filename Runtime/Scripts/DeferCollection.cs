/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System.Collections;
using System.Collections.Generic;

namespace Andtech
{

	public class DeferCollection<T> : IEnumerable<T>
	{
		private bool isLocked;
		private readonly ICollection<T> collection;
		private readonly Queue<T> pendingAdd;
		private readonly Queue<T> pendingRemove;

		public DeferCollection(ICollection<T> collection)
		{
			this.collection = collection;
			pendingAdd = new Queue<T>();
			pendingRemove = new Queue<T>();
		}

		public bool CanAdd(T item) => !collection.Contains(item);

		public bool CanRemove(T item) => collection.Contains(item);

		public void Add(T item)
		{
			if (isLocked)
			{
				pendingAdd.Enqueue(item);
			}
			else
			{
				collection.Add(item);
			}
		}

		public void Remove(T item)
		{
			if (isLocked)
			{
				pendingRemove.Enqueue(item);
			}
			else
			{
				collection.Remove(item);
			}
		}

		public void Flush()
		{
			foreach (var element in pendingAdd)
			{
				collection.Add(element);
			}
			foreach (var element in pendingRemove)
			{
				collection.Remove(element);
			}
			pendingAdd.Clear();
			pendingRemove.Clear();
		}

		public void Clear()
		{
			collection.Clear();
			pendingAdd.Clear();
			pendingRemove.Clear();
		}

		public void Lock() => isLocked = true;

		public void Unlock() => isLocked = false;

		public IEnumerator<T> GetEnumerator() => collection.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)collection).GetEnumerator();
	}
}
