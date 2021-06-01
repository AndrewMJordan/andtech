/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using NUnit.Framework;

namespace Andtech.Tests
{

    public static class MathTests
    {

        [Test]
        public static void TestRepeatPositive()
        {
            Assert.AreEqual(0, MathfA.Repeat(10, 10));
            Assert.AreEqual(1, MathfA.Repeat(11, 10));
            Assert.AreEqual(2, MathfA.Repeat(12, 10));
        }

        [Test]
        public static void TestRepeatNegative()
        {
            Assert.AreEqual(0, MathfA.Repeat(-10, 10));
            Assert.AreEqual(1, MathfA.Repeat(-9, 10));
            Assert.AreEqual(2, MathfA.Repeat(-8, 10));
        }

        [Test]
        public static void TestRepeatRange()
        {
            Assert.AreEqual(25, MathfA.Repeat(35, 20, 30));
            Assert.AreEqual(26, MathfA.Repeat(36, 20, 30));
            Assert.AreEqual(27, MathfA.Repeat(37, 20, 30));

            Assert.AreEqual(25, MathfA.Repeat(15, 20, 30));
            Assert.AreEqual(26, MathfA.Repeat(16, 20, 30));
            Assert.AreEqual(27, MathfA.Repeat(17, 20, 30));
        }

        [Test]
        public static void TestRepeatFloat()
        {
            Assert.AreEqual(25.0f, MathfA.Repeat(15.0f, 20.0f, 30.0f));
            Assert.AreEqual(26.0f, MathfA.Repeat(16.0f, 20.0f, 30.0f));
            Assert.AreEqual(27.0f, MathfA.Repeat(17.0f, 20.0f, 30.0f));

            Assert.AreEqual(25.0f, MathfA.Repeat(35.0f, 20.0f, 30.0f));
            Assert.AreEqual(26.0f, MathfA.Repeat(36.0f, 20.0f, 30.0f));
            Assert.AreEqual(27.0f, MathfA.Repeat(37.0f, 20.0f, 30.0f));
        }
    }
}
