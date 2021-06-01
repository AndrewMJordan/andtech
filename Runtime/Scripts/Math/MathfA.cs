/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech
{

    public static class MathfA
    {

        /// <summary>
        /// Loops the value <paramref name="t"/>, so that it is never larger than or equal to <paramref name="length"/> and never smaller than 0.
        /// </summary>
        /// <param name="t">The value to loop.</param>
        /// <param name="length">The upper bound (exclusive).</param>
        /// <returns>The looped value.</returns>
        public static int Repeat(int t, int length) => Repeat(t, 0, length);

        /// <summary>
        /// Loops the value <paramref name="t"/>, so that it is never larger than or equal to <paramref name="length"/> and never smaller than 0.
        /// </summary>
        /// <param name="t">The value to loop.</param>
        /// <param name="length">The upper bound (exclusive).</param>
        /// <param name="repeatCount">The number of repetitions of the variables.</param>
        /// <returns>The looped value.</returns>
        public static int Repeat(int t, int length, out int repeatCount) => Repeat(t, 0, length, out repeatCount);

        /// <summary>
        /// Loops the value <paramref name="t"/>, so that it is never larger than or equal to <paramref name="max"/> and never smaller than <paramref name="min"/>.
        /// </summary>
        /// <param name="t">The value to loop.</param>
        /// <param name="min">The lower bound (inclusive).</param>
        /// <param name="max">The upper bound (exclusive).</param>
        /// <returns>The looped value.</returns>
        public static int Repeat(int t, int min, int max) => Repeat(t, min, max, out var repeatCount);

        /// <summary>
        /// Loops the value <paramref name="t"/>, so that it is never larger than or equal to <paramref name="max"/> and never smaller than <paramref name="min"/>.
        /// </summary>
        /// <param name="t">The value to loop.</param>
        /// <param name="min">The lower bound (inclusive).</param>
        /// <param name="max">The upper bound (exclusive).</param>
        /// <param name="repeatCount">The number of repetitions of the variables.</param>
        /// <returns>The looped value.</returns>
        public static int Repeat(int t, int min, int max, out int repeatCount)
        {
            var range = max - min;
            if (range <= 1)
            {
                repeatCount = 0;
                return min;
            }

            if (t < min)
            {
                max -= 1;
                var distance = max - t;
                repeatCount = distance / range;
                return max - (distance % range);
            }
            else
            {
                var distance = t - min;
                repeatCount = distance / range;
                return (distance % range) + min;
            }
        }

        /// <summary>
        /// Loops the value <paramref name="t"/>, so that it is never larger than <paramref name="max"/> and never smaller than <paramref name="min"/>.
        /// </summary>
        /// <param name="t">The value to loop.</param>
        /// <param name="min">The lower bound (inclusive).</param>
        /// <param name="max">The upper bound (exclusive).</param>
        /// <returns>The looped value.</returns>
        public static float Repeat(float t, float min, float max) => min + Mathf.Repeat(t - min, max - min);

        /// <summary>
        /// Returns the greatest common divisor between <paramref name="a"/> and <paramref name="b"/>.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The greatest common divisor.</returns>
        public static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);

        /// <summary>
        /// Returns the greatest common divisor between all values.
        /// </summary>
        /// <param name="values">The set of values.</param>
        /// <returns>The greates common divisor.</returns>
        public static int GCD(params int[] values)
        {
            int lastGCD = values[0];
            int n = values.Length;
            for (int i = 1; i < n; i++)
            {
                lastGCD = GCD(lastGCD, values[i]);
            }

            return lastGCD;
        }
    }
}
