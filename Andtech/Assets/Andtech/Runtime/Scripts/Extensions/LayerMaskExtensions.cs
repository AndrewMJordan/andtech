using UnityEngine;

namespace Andtech
{

	public static class LayerMaskExtensions
	{

		/// <summary>
		/// Determines whether a layer is set in the layer mask.
		/// </summary>
		/// <param name="layerMask">The layer mask to test.</param>
		/// <param name="layer">A layer value.</param>
		/// <returns>The layer is set in the layer mask.</returns>
		public static bool HasLayer(this LayerMask layerMask, int layer) => HasFlag(layerMask, 1 << layer);

		/// <summary>
		/// Determines whether layers are set in the layer mask.
		/// </summary>
		/// <param name="layerMask">The layer mask to test.</param>
		/// <param name="mask">A mask of layers.</param>
		/// <returns>All layers are set in the layer mask.</returns>
		public static bool HasFlag(this LayerMask layerMask, int mask) => (layerMask.value & mask) != 0;
	}
}
