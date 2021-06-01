/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System.Collections.Generic;
using UnityEngine;

namespace Andtech
{

    /// <summary>
    /// Useful vector functions.
    /// </summary>
    public static class VectorUtility
    {

        /// <summary>
        /// Projects <paramref name="vector"/> onto the plane spanned by <see cref="Vector3.right"/>.
        /// </summary>
        /// <param name="vector">The vector to project.</param>
        /// <returns>The projected copy of <paramref name="vector"/>.</returns>
        public static Vector3 ProjectOnPlaneX(Vector3 vector) => new Vector3(0.0f, vector.y, vector.z);

        /// <summary>
        /// Projects <paramref name="vector"/> onto the plane spanned by <see cref="Vector3.up"/>.
        /// </summary>
        /// <param name="vector">The vector to project.</param>
        /// <returns>The projected copy of <paramref name="vector"/>.</returns>
        public static Vector3 ProjectOnPlaneY(Vector3 vector) => new Vector3(vector.x, 0.0f, vector.z);

        /// <summary>
        /// Projects <paramref name="vector"/> onto the plane spanned by <see cref="Vector3.forward"/>.
        /// </summary>
        /// <param name="vector">The vector to project.</param>
        /// <returns>The projected copy of <paramref name="vector"/>.</returns>
        public static Vector3 ProjectOnPlaneZ(Vector3 vector) => new Vector3(vector.x, vector.y, 0.0f);

        /// <summary>
        /// Optimized version of an orthogonal projection onto a line spanned by <paramref name="onNormal"/>.
        /// </summary>
        /// <param name="vector">The vector to project.</param>
        /// <param name="onNormal">The vector which defines the line (normalized).</param>
        /// <returns>The projected copy of <paramref name="vector"/>.</returns>
        public static Vector3 ProjectOptimized(Vector3 vector, Vector3 onNormal) => Vector3.Dot(vector, onNormal) * onNormal;

        /// <summary>
        /// Optimized version of orthogonal projection onto a plane defined by <paramref name="planeNormal"/>.
        /// </summary>
        /// <param name="vector">The vector to project.</param>
        /// <param name="planeNormal">The vector which defines the line (normalized).</param>
        /// <returns>The projected copy of <paramref name="vector"/>.</returns>
        public static Vector3 ProjectOnPlaneOptimized(Vector3 vector, Vector3 planeNormal) => vector - ProjectOptimized(vector, planeNormal);

        /// <summary>
        /// Computes the cross product of <paramref name="vector"/> and <see cref="Vector3.right"/>.
        /// </summary>
        /// <param name="vector">The vector to use in the cross product.</param>
        /// <returns>The cross product of <paramref name="vector"/>.</returns>
        public static Vector3 CrossRight(Vector3 vector) => new Vector3(0.0f, vector.z, -vector.y);

        /// <summary>
        /// Computes the cross product of <paramref name="vector"/> and <see cref="Vector3.up"/>.
        /// </summary>
        /// <param name="vector">The vector to use in the cross product.</param>
        /// <returns>The cross product of <paramref name="vector"/>.</returns>
        public static Vector3 CrossUp(Vector3 vector) => new Vector3(-vector.z, 0.0f, vector.x);

        /// <summary>
        /// Computes the cross product of <paramref name="vector"/> and <see cref="Vector3.forward"/>.
        /// </summary>
        /// <param name="vector">The vector to use in the cross product.</param>
        /// <returns>The cross product of <paramref name="vector"/>.</returns>
        public static Vector3 CrossForward(Vector3 vector) => new Vector3(vector.y, -vector.x, 0.0f);

        /// <summary>
        /// Computes the intersection of (1) the ray defined by <paramref name="point"/> and <paramref name="direction"/> and the XZ plane.
        /// </summary>
        /// <param name="point">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <param name="intersection">The point of intersection.</param>
        /// <returns>Is there a valid 
        public static bool LinePlaneIntersection(Vector3 point, Vector3 direction, out Vector3 intersection)
        {
            float t = -point.y / direction.y;
            intersection = point + t * direction;

            return t.CompareTo(0.0f) >= 0;
        }

        /// <summary>
        /// Computes the intersection of (1) the ray defined by <paramref name="point"/> and <paramref name="direction"/> and (2) the plane defined by <paramref name="planeOrigin"/> and <paramref name="planeNormal"/>.
        /// </summary>
        /// <param name="point">The origin of the ray.</param>
        /// <param name="direction">The direction of the ray.</param>
        /// <param name="intersection">The point of intersection.</param>
        /// <param name="planeOrigin">Any position on the plane.</param>
        /// <param name="planeNormal">The normal of the plane.</param>
        /// <returns>Is there a valid intersection point?</returns>
        public static bool LinePlaneIntersection(Vector3 point, Vector3 direction, out Vector3 intersection, Vector3 planeOrigin, Vector3 planeNormal)
        {
            float t = (Vector3.Dot(planeNormal, planeOrigin) - Vector3.Dot(planeNormal, point)) / Vector3.Dot(planeNormal, direction);
            intersection = point + t * direction;

            return t.CompareTo(0.0f) >= 0;
        }

        /// <summary>
        /// Computes the intersection of (1) the line defined by <paramref name="p0"/> and <paramref name="d0"/> and (2) the line defined by <paramref name="p1"/> and <paramref name="d1"/>.
        /// </summary>
        /// <param name="p0">Any point on the first line.</param>
        /// <param name="d0">The direction of the first line.</param>
        /// <param name="p1">Any point on the second line.</param>
        /// <param name="d1">The direction of second line.</param>
        /// <param name="intersection">The point of intersection.</param>
        /// <returns>Is there a valid intersection point?</returns>
        public static bool LineLineIntersection(Vector3Int p0, Vector3Int d0, Vector3Int p1, Vector3Int d1, out Vector3Int intersection)
        {
            Vector3Int delta = p1 - p0;
            Vector3Int crossVec0and1 = VECTOR3INT.Cross(d0, d1);
            Vector3Int crossDeltaAnd1 = VECTOR3INT.Cross(delta, d1);

            int planarFactor = VECTOR3INT.Dot(delta, crossVec0and1);
            var isCoplanar = planarFactor == 0;
            var isParallel = crossVec0and1.sqrMagnitude == 0;

            if (isCoplanar && !isParallel)
            {
                int s = VECTOR3INT.Dot(crossDeltaAnd1, crossVec0and1) / crossVec0and1.sqrMagnitude;
                intersection = p0 + s * d0;
                return true;
            }
            else
            {
                intersection = Vector3Int.zero;
                return false;
            }
        }

        /// <summary>
        /// Computes the decomposition vectors of <paramref name="vector"/>.
        /// </summary>
        /// <param name="vector">The vector to decompose.</param>
        /// <returns>The set of decomposition vectors.</returns>
        public static IEnumerable<Vector3Int> Decompose(Vector3Int vector)
        {
            Vector3Int current;
            current = new Vector3Int(vector.x, 0, 0);
            if (current != Vector3Int.zero)
            {
                yield return current;
            }

            current = new Vector3Int(0, vector.y, 0);
            if (current != Vector3Int.zero)
            {
                yield return current;
            }

            current = new Vector3Int(vector.x, vector.y, 0);
            if (current != Vector3Int.zero)
            {
                yield return current;
            }

            current = new Vector3Int(0, 0, vector.z);
            if (current != Vector3Int.zero)
            {
                yield return current;
            }

            current = new Vector3Int(vector.x, 0, vector.z);
            if (current != Vector3Int.zero)
            {
                yield return current;
            }

            current = new Vector3Int(0, vector.y, vector.z);
            if (current != Vector3Int.zero)
            {
                yield return current;
            }

            current = new Vector3Int(vector.x, vector.y, vector.z);
            if (current != Vector3Int.zero)
            {
                yield return current;
            }
        }
    }
}
