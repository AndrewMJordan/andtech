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

	public class ChainTests
	{

		[Test]
		public void TestTrivialChain()
		{
			var chain = new Chain<int>();

			var result = chain.Run(10);

			Assert.AreEqual(10, result);
		}

		[Test]
		public void TestModifiedChain()
		{
			var chain = new Chain<int>(Subtract);

			var result = chain.Run(10);

			Assert.AreEqual(9, result);

			int Subtract(in int input)
			{
				return input - 1;
			}
		}

		[Test]
		public void TestBooleanChain()
		{
			var chain = new Chain<bool>(TestAndTrue, TestAndFalse, TestAndTrue);
			var result = chain.Run(true);
			Assert.IsFalse(result);

			chain = new Chain<bool>(Invert, Passthrough, Invert, Invert);
			result = chain.Run(false);
			Assert.IsFalse(false);

			bool Passthrough(in bool x) {
				return x;
			}

			bool Invert(in bool x)
			{
				return !x;
			}

			bool TestAndTrue(in bool x)
			{
				return x & true;
			}

			bool TestAndFalse(in bool x)
			{
				return x & false;
			}
		}
	}
}
