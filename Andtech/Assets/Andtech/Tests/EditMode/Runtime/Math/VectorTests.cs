﻿using NUnit.Framework;
using UnityEngine;

namespace Andtech.Tests
{

    public static class VectorTests
    {

        [Test]
        public static void TestCrossProduct()
        {
            var right = Vector3Int.right;
            var left = Vector3Int.left;
            var down = Vector3Int.down;
            var up = Vector3Int.up;
            var back = new Vector3Int(0, 0, -1);
            var forward = new Vector3Int(0, 0, 1);

            Assert.AreEqual(forward, VECTOR3INT.Cross(right, up));
        }
    }
}
