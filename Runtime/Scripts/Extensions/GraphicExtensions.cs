/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;
using UnityEngine.UI;

namespace Andtech {

	public static class GraphicExtensions {

		public static void SetColor(this Graphic graphic, Color color) => graphic.color = color;
	}
}
