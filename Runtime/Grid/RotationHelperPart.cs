/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech {

	public partial struct Rotation {

		private static readonly float DOT_60 = Mathf.Cos(60.0F * Mathf.Deg2Rad);

		public static Rotation LookRotation(int x, int y, int z) => LookRotation(new Vector3Int(x, y, z));

		public static Rotation LookRotation(Vector3 forward) {
			forward.Normalize();
			var dotX = Vector3.Dot(forward, Vector3.right);
			var dotY = Vector3.Dot(forward, Vector3.up);
			var dotZ = Vector3.Dot(forward, Vector3.forward);

			return LookRotation(
				DotToSign(dotX),
				DotToSign(dotY),
				DotToSign(dotZ)
			);

			int DotToSign(float dot) {
				if (dot < -DOT_60)
					return -1;

				if (dot >= DOT_60)
					return 1;

				return 0;
			}
		}

		public static Rotation LookRotation(float x, float y, float z) => LookRotation(new Vector3(x, y, z));

		public Quaternion Quaternion => Quaternion.LookRotation(Basis2, Basis1);
	}
}
