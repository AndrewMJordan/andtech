/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System.Collections.Generic;

namespace Andtech
{

	/// <summary>
	/// A sequential chain of modifiers.
	/// </summary>
	/// <typeparam name="T">The type of the items being modified.</typeparam>
	public class Chain<T>
	{
		private readonly LinkedList<Operation> modifiers;

		/// <summary>
		/// Creates a chain with predefined modify operations.
		/// </summary>
		/// <param name="operations">The modify operations.</param>
		public Chain(params Operation[] operations)
		{
			modifiers = new LinkedList<Operation>(operations);
		}

		/// <summary>
		/// Adds a modifier stage to the chain.
		/// </summary>
		/// <param name="modifier">The modify operation.</param>
		public void Add(Operation modifier) => modifiers.AddLast(modifier);

		/// <summary>
		/// Removes a modifier stage to the chain.
		/// </summary>
		/// <param name="operation">The modify operation.</param>
		public void Remove(Operation operation) => modifiers.Remove(operation);

		/// <summary>
		/// Transforms <paramref name="input"/> through the chain.
		/// </summary>
		/// <param name="input">The input value.</param>
		/// <returns>The output value.</returns>
		public T Run(in T input)
		{
			var output = input;

			foreach (var modifier in modifiers)
			{
				output = modifier(output);
			}

			return output;
		}

		public delegate T Operation(in T input);
	}
}
