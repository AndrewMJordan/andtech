using UnityEngine;

namespace Andtech
{

    public static class Vector2Extensions
    {

        /// <summary>
        /// Selects components from a vector.
        /// </summary>
        /// <param name="original">The original vector.</param>
        /// <param name="x">New x component value.</param>
        /// <param name="y">New y component value.</param>
        /// <returns>A combination of the original and new values.</returns>
        public static Vector2 With(this Vector2 original, float? x = null, float? y = null) => new Vector3
        {
            x = x ?? original.x,
            y = y ?? original.y
        };

        /// <summary>
        /// Makes this <paramref name="vector"/> have a magnitude of 1.
        /// </summary>
        /// <param name="vector">The vector to scale.</param>
        /// <param name="length">The length of the original vector.</param>
        public static void Normalize(this ref Vector2 vector, out float length)
        {
            length = vector.magnitude;
            vector /= length;
        }

        /// <summary>
        /// Returns the components rounded to the nearest integer.
        /// </summary>
        /// <param name="vector">The vector whose components should be rounded.</param>
        /// <returns>The vector with rounded components.</returns>
        public static Vector2 Round(this Vector2 vector)
        {
            return new Vector2()
            {
                x = Mathf.Round(vector.x),
                y = Mathf.Round(vector.y)
            };
        }

        /// <summary>
        /// Returns the components rounded to the nearest integer.
        /// </summary>
        /// <param name="vector">The vector whose components should be rounded.</param>
        /// <returns>The vector with rounded components.</returns>
        public static Vector2Int RoundToInt(this Vector2 vector)
        {
            return new Vector2Int()
            {
                x = Mathf.RoundToInt(vector.x),
                y = Mathf.RoundToInt(vector.y)
            };
        }

        /// <summary>
        /// Returns the largest integer smaller than or equal to f (for each component).
        /// </summary>
        /// <param name="vector">The vector whose components should be floored.</param>
        /// <returns>The vector with floored components.</returns>
        public static Vector2 Floor(this Vector2 vector)
        {
            return new Vector2()
            {
                x = Mathf.Floor(vector.x),
                y = Mathf.Floor(vector.y)
            };
        }

        /// <summary>
        /// Returns the largest integer smaller than or equal to f (for each component).
        /// </summary>
        /// <param name="vector">The vector whose components should be floored.</param>
        /// <returns>The vector with floored components.</returns>
        public static Vector2Int FloorToInt(this Vector2 vector)
        {
            return new Vector2Int()
            {
                x = Mathf.FloorToInt(vector.x),
                y = Mathf.FloorToInt(vector.y)
            };
        }

        /// <summary>
        /// Returns the largest integer greater than or equal to f (for each component).
        /// </summary>
        /// <param name="vector">The vector whose components should be ceiled.</param>
        /// <returns>The vector with ceiled components.</returns>
        public static Vector2 Ceil(this Vector2 vector)
        {
            return new Vector2()
            {
                x = Mathf.Ceil(vector.x),
                y = Mathf.Ceil(vector.y)
            };
        }

        /// <summary>
        /// Returns the largest integer greater than or equal to f (for each component).
        /// </summary>
        /// <param name="vector">The vector whose components should be ceiled.</param>
        /// <returns>The vector with ceiled components.</returns>
        public static Vector2Int CeilToInt(this Vector2 vector)
        {
            return new Vector2Int()
            {
                x = Mathf.CeilToInt(vector.x),
                y = Mathf.CeilToInt(vector.y)
            };
        }

        /// <summary>
        /// Returns a component-wise reciprocal of <paramref name="vector"/>.
        /// </summary>
        /// <param name="vector">The vector to reciprocate.</param>
        /// <returns>The reciprocal of <paramref name="vector"/>.</returns>
        public static Vector2 Reciprocal(this Vector2 vector)
        {
            return new Vector2()
            {
                x = 1.0f / vector.x,
                y = 1.0f / vector.y
            };
        }

        /// <summary>
        /// Divides the current vector component-wise by another.
        /// </summary>
        /// <param name="a">The divident vector.</param>
        /// <param name="b">The divisor vector</param>
        /// <returns>A vector of component-wise quotients.</returns>
        public static Vector2 DivideBy(this Vector2 a, Vector2 b)
        {
            return new Vector2()
            {
                x = a.x / b.x,
                y = a.y / b.y
            };
        }
    }
}
