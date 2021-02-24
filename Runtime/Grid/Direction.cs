/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;

namespace Andtech {

	/// <summary>
	/// Represents a cardinal direction in 3D.
	/// </summary>
	[Flags]
	public enum Direction {
		Zero = ZZZ,

		Left = NZZ,
		Right = PZZ,
		Down = ZNZ,
		Up = ZPZ,
		Back = ZZN,
		Forward = ZZP,

		ZZZ = 0,
		NNN = 1 << 1,
		NNZ = 1 << 2,
		NNP = 1 << 3,
		NZN = 1 << 4,
		NZZ = 1 << 5,
		NZP = 1 << 6,
		NPN = 1 << 7,
		NPZ = 1 << 8,
		NPP = 1 << 9,
		ZNN = 1 << 10,
		ZNZ = 1 << 11,
		ZNP = 1 << 12,
		ZZN = 1 << 13,
		ZZP = 1 << 14,
		ZPN = 1 << 15,
		ZPZ = 1 << 16,
		ZPP = 1 << 17,
		PNN = 1 << 18,
		PNZ = 1 << 19,
		PNP = 1 << 20,
		PZN = 1 << 21,
		PZZ = 1 << 22,
		PZP = 1 << 23,
		PPN = 1 << 24,
		PPZ = 1 << 25,
		PPP = 1 << 26
	}
}
