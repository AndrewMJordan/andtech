/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

namespace Andtech.Samples
{

	public static class SimplePinExtensions
	{

		public static void Link(this Viewport viewport, SimplePin pin)
		{
			pin.Viewport = viewport;
		}

		public static void Unlink(this Viewport viewport, SimplePin pin)
		{
			pin.Viewport = null;
		}
	}
}
