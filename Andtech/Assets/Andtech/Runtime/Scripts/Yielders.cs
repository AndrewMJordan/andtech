using System.Collections.Generic;
using UnityEngine;

namespace Andtech
{

	public static class Yielders
	{
		private static readonly WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
		private static readonly WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
		private static readonly Dictionary<float, WaitForSeconds> waitForSecondsCache = new Dictionary<float, WaitForSeconds>(cacheSize, new FloatComparer());
		private static readonly Dictionary<float, WaitForSecondsRealtime> waitForSecondsRealtimeCache = new Dictionary<float, WaitForSecondsRealtime>(cacheSize, new FloatComparer());
		private static readonly Queue<float> accessQueue = new Queue<float>(cacheSize);
		private static readonly Queue<float> accessQueueRealtime = new Queue<float>(cacheSize);
		private static int cacheSize = 32;

		public static YieldInstruction WaitForPostFixedUpdate => waitForFixedUpdate;

		public static YieldInstruction WaitForPostUpdate => null;

		public static YieldInstruction WaitForEndOfFrame => waitForEndOfFrame;

		public static WaitForSeconds WaitForSeconds(float duration)
		{
			if (!waitForSecondsCache.TryGetValue(duration, out var wait))
			{
				if (accessQueue.Count >= cacheSize)
				{
					var key = accessQueue.Dequeue();
					waitForSecondsCache.Remove(key);
				}

				accessQueue.Enqueue(duration);
				waitForSecondsCache.Add(duration, wait = new WaitForSeconds(duration));
			}

			return wait;
		}

		public static WaitForSecondsRealtime WaitForSecondsRealtime(float duration)
		{
			if (!waitForSecondsRealtimeCache.TryGetValue(duration, out var wait))
			{
				if (accessQueueRealtime.Count >= cacheSize)
				{
					var key = accessQueueRealtime.Dequeue();
					waitForSecondsRealtimeCache.Remove(key);
				}

				accessQueueRealtime.Enqueue(duration);
				waitForSecondsRealtimeCache.Add(duration, wait = new WaitForSecondsRealtime(duration));
			}

			return wait;
		}

		class FloatComparer : IEqualityComparer<float>
		{
			bool IEqualityComparer<float>.Equals(float x, float y)
			{
				return x.CompareTo(y) == 0;
			}
			int IEqualityComparer<float>.GetHashCode(float obj)
			{
				return obj.GetHashCode();
			}
		}
	}
}