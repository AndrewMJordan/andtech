/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System.Collections.Generic;
using UnityEngine;

namespace Andtech {

	public partial struct Rotation {
		private static readonly Vector3Int VectorNNN = new Vector3Int(-1, -1, -1);
		private static readonly Vector3Int VectorNNZ = new Vector3Int(-1, -1, 0);
		private static readonly Vector3Int VectorNNP = new Vector3Int(-1, -1, 1);
		private static readonly Vector3Int VectorNZN = new Vector3Int(-1, 0, -1);
		private static readonly Vector3Int VectorNZZ = new Vector3Int(-1, 0, 0);
		private static readonly Vector3Int VectorNZP = new Vector3Int(-1, 0, 1);
		private static readonly Vector3Int VectorNPN = new Vector3Int(-1, 1, -1);
		private static readonly Vector3Int VectorNPZ = new Vector3Int(-1, 1, 0);
		private static readonly Vector3Int VectorNPP = new Vector3Int(-1, 1, 1);
		private static readonly Vector3Int VectorZNN = new Vector3Int(0, -1, -1);
		private static readonly Vector3Int VectorZNZ = new Vector3Int(0, -1, 0);
		private static readonly Vector3Int VectorZNP = new Vector3Int(0, -1, 1);
		private static readonly Vector3Int VectorZZN = new Vector3Int(0, 0, -1);
		private static readonly Vector3Int VectorZZZ = new Vector3Int(0, 0, 0);
		private static readonly Vector3Int VectorZZP = new Vector3Int(0, 0, 1);
		private static readonly Vector3Int VectorZPN = new Vector3Int(0, 1, -1);
		private static readonly Vector3Int VectorZPZ = new Vector3Int(0, 1, 0);
		private static readonly Vector3Int VectorZPP = new Vector3Int(0, 1, 1);
		private static readonly Vector3Int VectorPNN = new Vector3Int(1, -1, -1);
		private static readonly Vector3Int VectorPNZ = new Vector3Int(1, -1, 0);
		private static readonly Vector3Int VectorPNP = new Vector3Int(1, -1, 1);
		private static readonly Vector3Int VectorPZN = new Vector3Int(1, 0, -1);
		private static readonly Vector3Int VectorPZZ = new Vector3Int(1, 0, 0);
		private static readonly Vector3Int VectorPZP = new Vector3Int(1, 0, 1);
		private static readonly Vector3Int VectorPPN = new Vector3Int(1, 1, -1);
		private static readonly Vector3Int VectorPPZ = new Vector3Int(1, 1, 0);
		private static readonly Vector3Int VectorPPP = new Vector3Int(1, 1, 1);

		/// <summary>
		/// Encodes the rotation to a direction mask.
		/// </summary>
		/// <param name="rotation">The rotation to encode.</param>
		/// <returns>The mask in which the flag corresponding to <paramref name="rotation"/> is set.</returns>
		public static Direction Encode(Rotation rotation) {
			var forward = rotation * VECTOR3INT.forward;
			if (forward == VectorNNZ)
				return Direction.NNZ;
			if (forward == VectorNNP)
				return Direction.NNP;
			if (forward == VectorNZN)
				return Direction.NZN;
			if (forward == VectorNZZ)
				return Direction.NZZ;
			if (forward == VectorNZP)
				return Direction.NZP;
			if (forward == VectorNPN)
				return Direction.NPN;
			if (forward == VectorNPZ)
				return Direction.NPZ;
			if (forward == VectorNPP)
				return Direction.NPP;
			if (forward == VectorZNN)
				return Direction.ZNN;
			if (forward == VectorZNZ)
				return Direction.ZNZ;
			if (forward == VectorZNP)
				return Direction.ZNP;
			if (forward == VectorZZN)
				return Direction.ZZN;
			if (forward == VectorZZP)
				return Direction.ZZP;
			if (forward == VectorZPN)
				return Direction.ZPN;
			if (forward == VectorZPZ)
				return Direction.ZPZ;
			if (forward == VectorZPP)
				return Direction.ZPP;
			if (forward == VectorPNN)
				return Direction.PNN;
			if (forward == VectorPNZ)
				return Direction.PNZ;
			if (forward == VectorPNP)
				return Direction.PNP;
			if (forward == VectorPZN)
				return Direction.PZN;
			if (forward == VectorPZZ)
				return Direction.PZZ;
			if (forward == VectorPZP)
				return Direction.PZP;
			if (forward == VectorPPN)
				return Direction.PPN;
			if (forward == VectorPPZ)
				return Direction.PPZ;
			if (forward == VectorPPP)
				return Direction.PPP;

			return default;
		}

		/// <summary>
		/// Encodes the set of rotations to a direction mask.
		/// </summary>
		/// <param name="rotations">The rotations to encode.</param>
		/// <returns>The mask in which the flags corresponding to <paramref name="rotations"/> are set.</returns>
		public static Direction Encode(IEnumerable<Rotation> rotations) {
			var mask = Direction.Zero;
			foreach (var rotation in rotations)
				mask |= Encode(rotation);

			return mask;
		}

		/// <summary>
		/// Decodes the direction mask into a rotation.
		/// </summary>
		/// <param name="mask">The mask representing the forward vector.</param>
		/// <returns>The rotation which corresponds to the flag in <paramref name="mask"/>.</returns>
		public static Rotation Decode(Direction mask) {
			if (mask.HasFlag(Direction.NNZ))
				return LookRotation(VectorNNZ);
			if (mask.HasFlag(Direction.NNP))
				return LookRotation(VectorNNP);
			if (mask.HasFlag(Direction.NZN))
				return LookRotation(VectorNZN);
			if (mask.HasFlag(Direction.NZZ))
				return LookRotation(VectorNZZ);
			if (mask.HasFlag(Direction.NZP))
				return LookRotation(VectorNZP);
			if (mask.HasFlag(Direction.NPN))
				return LookRotation(VectorNPN);
			if (mask.HasFlag(Direction.NPZ))
				return LookRotation(VectorNPZ);
			if (mask.HasFlag(Direction.NPP))
				return LookRotation(VectorNPP);
			if (mask.HasFlag(Direction.ZNN))
				return LookRotation(VectorZNN);
			if (mask.HasFlag(Direction.ZNZ))
				return LookRotation(VectorZNZ);
			if (mask.HasFlag(Direction.ZNP))
				return LookRotation(VectorZNP);
			if (mask.HasFlag(Direction.ZZN))
				return LookRotation(VectorZZN);
			if (mask.HasFlag(Direction.ZZP))
				return LookRotation(VectorZZP);
			if (mask.HasFlag(Direction.ZPN))
				return LookRotation(VectorZPN);
			if (mask.HasFlag(Direction.ZPZ))
				return LookRotation(VectorZPZ);
			if (mask.HasFlag(Direction.ZPP))
				return LookRotation(VectorZPP);
			if (mask.HasFlag(Direction.PNN))
				return LookRotation(VectorPNN);
			if (mask.HasFlag(Direction.PNZ))
				return LookRotation(VectorPNZ);
			if (mask.HasFlag(Direction.PNP))
				return LookRotation(VectorPNP);
			if (mask.HasFlag(Direction.PZN))
				return LookRotation(VectorPZN);
			if (mask.HasFlag(Direction.PZZ))
				return LookRotation(VectorPZZ);
			if (mask.HasFlag(Direction.PZP))
				return LookRotation(VectorPZP);
			if (mask.HasFlag(Direction.PPN))
				return LookRotation(VectorPPN);
			if (mask.HasFlag(Direction.PPZ))
				return LookRotation(VectorPPZ);
			if (mask.HasFlag(Direction.PPP))
				return LookRotation(VectorPPP);

			return Identity;
		}

		/// <summary>
		/// Decodes all rotations from <paramref name="mask"/>.
		/// </summary>
		/// <param name="mask">The mask containing forward vectors.</param>
		/// <returns>The set of rotations indicated by <paramref name="mask"/>.</returns>
		public static IEnumerable<Rotation> DecodeMany(Direction mask) {
			if (mask.HasFlag(Direction.NNZ))
				yield return LookRotation(VectorNNZ);
			if (mask.HasFlag(Direction.NNP))
				yield return LookRotation(VectorNNP);
			if (mask.HasFlag(Direction.NZN))
				yield return LookRotation(VectorNZN);
			if (mask.HasFlag(Direction.NZZ))
				yield return LookRotation(VectorNZZ);
			if (mask.HasFlag(Direction.NZP))
				yield return LookRotation(VectorNZP);
			if (mask.HasFlag(Direction.NPN))
				yield return LookRotation(VectorNPN);
			if (mask.HasFlag(Direction.NPZ))
				yield return LookRotation(VectorNPZ);
			if (mask.HasFlag(Direction.NPP))
				yield return LookRotation(VectorNPP);
			if (mask.HasFlag(Direction.ZNN))
				yield return LookRotation(VectorZNN);
			if (mask.HasFlag(Direction.ZNZ))
				yield return LookRotation(VectorZNZ);
			if (mask.HasFlag(Direction.ZNP))
				yield return LookRotation(VectorZNP);
			if (mask.HasFlag(Direction.ZZN))
				yield return LookRotation(VectorZZN);
			if (mask.HasFlag(Direction.ZZP))
				yield return LookRotation(VectorZZP);
			if (mask.HasFlag(Direction.ZPN))
				yield return LookRotation(VectorZPN);
			if (mask.HasFlag(Direction.ZPZ))
				yield return LookRotation(VectorZPZ);
			if (mask.HasFlag(Direction.ZPP))
				yield return LookRotation(VectorZPP);
			if (mask.HasFlag(Direction.PNN))
				yield return LookRotation(VectorPNN);
			if (mask.HasFlag(Direction.PNZ))
				yield return LookRotation(VectorPNZ);
			if (mask.HasFlag(Direction.PNP))
				yield return LookRotation(VectorPNP);
			if (mask.HasFlag(Direction.PZN))
				yield return LookRotation(VectorPZN);
			if (mask.HasFlag(Direction.PZZ))
				yield return LookRotation(VectorPZZ);
			if (mask.HasFlag(Direction.PZP))
				yield return LookRotation(VectorPZP);
			if (mask.HasFlag(Direction.PPN))
				yield return LookRotation(VectorPPN);
			if (mask.HasFlag(Direction.PPZ))
				yield return LookRotation(VectorPPZ);
			if (mask.HasFlag(Direction.PPP))
				yield return LookRotation(VectorPPP);
		}
	}
}
