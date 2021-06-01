/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using UnityEngine;

namespace Andtech
{

    /// <summary>
    /// Useful intersection functions.
    /// </summary>
    public static class IntersectionUtility
    {

        /// <summary>
        /// Gets the position of the intersection between two rays.
        /// </summary>
        /// <param name="positionA">The origin of the first ray.</param>
        /// <param name="directionA">The direction of the first ray.</param>
        /// <param name="positionB">The origin of the second ray.</param>
        /// <param name="directionB">The direction of the second ray.</param>
        /// <returns>The world-space position of the intersection.</returns>
        public static Vector2 GetIntersection(Vector2 positionA, Vector2 directionA, Vector2 positionB, Vector2 directionB)
        {
            Vector2 delta = positionB - positionA;

            // Compute "determinant" term
            float determinant = directionA.x * directionB.y - directionA.y * directionB.x;
            if (determinant == 0)
            {
                throw new ArithmeticException("The rays do not intersect in R^2");
            }

            // Solve for scale factors (s, t)
            float numeratorS = delta.x * directionB.y - delta.y * directionA.x;
            float s = numeratorS / determinant;

            return positionA + s * directionA;
        }

        /// <summary>
        /// Gets the position of the intersection between two rays.
        /// </summary>
        /// <param name="positionA">The origin of the first ray.</param>
        /// <param name="directionA">The direction of the first ray.</param>
        /// <param name="positionB">The origin of the second ray.</param>
        /// <param name="directionB">The direction of the second ray.</param>
        /// <param name="s">How much <paramref name="directionA"/> needed to be scaled.</param>
        /// <param name="t">How much <paramref name="directionB"/> needed to be scaled.</param>
        /// <returns>The world-space position of the intersection.</returns>
        public static Vector2 GetIntersection(Vector2 positionA, Vector2 directionA, Vector2 positionB, Vector2 directionB, out float s, out float t)
        {
            Vector2 delta = positionB - positionA;

            // Compute "determinant" term
            float determinant = directionA.x * directionB.y - directionA.y * directionB.x;
            if (determinant == 0)
            {
                throw new ArithmeticException("The rays do not intersect in R^2");
            }

            // Solve for scale factors (s, t)
            float numeratorS = delta.x * directionB.y - delta.y * directionB.x;
            s = numeratorS / determinant;
            float numeratorT = delta.x * directionA.y - delta.y * directionA.x;
            t = numeratorT / determinant;

            return positionA + s * directionA;
        }

        /// <summary>
        /// Determines whether the two line segments intersect.
        /// </summary>
        /// <param name="originA">The origin of the first segment.</param>
        /// <param name="terminusA">The terminus of the first segment.</param>
        /// <param name="originB">The origin of the second segment.</param>
        /// <param name="terminusB">The terminus of the second segment.</param>
        /// <returns>The two line segments intersect in R^2.</returns>
        public static bool Intersects(Vector2 originA, Vector2 terminusA, Vector2 originB, Vector2 terminusB)
        {
            Vector2 directionA = terminusA - originA;
            Vector2 directionB = terminusB - originB;
            Vector2 delta = originB - originA;

            // Compute "determinant" term
            float determinant = directionA.x * directionB.y - directionA.y * directionB.x;
            if (determinant.CompareTo(0.0f) == 0)
            {
                return false;
            }

            // Solve for scale factors (s, t)
            float numeratorS = delta.x * directionB.y - delta.y * directionB.x;
            float s = numeratorS / determinant;
            if (s < 0.0f || s > 1.0f)
            {
                return false;
            }

            float numeratorT = delta.x * directionA.y - delta.y * directionA.x;
            float t = numeratorT / determinant;
            if (t < 0.0f || t > 1.0f)
            {
                return false;
            }

            return true;
        }
    }
}
