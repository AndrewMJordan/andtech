/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Andtech.Tests {

	public static class AgerTests {
		private static GameObject target;

		[OneTimeSetUp]
		public static void LoadScene() {
			SceneManager.LoadScene("Interpolate Testbed");
			target = GameObject.Find("Target");
		}

		[UnityTest]
		public static IEnumerator AgerTestsWithEnumeratorPasses() {
			var initialValue = 100.0F;
			var weight = 0.5F;
			var halfLife = Mathf.Log(0.5F, weight);

			var ager = new Ager(weight, initialValue);
			foreach (var alpha in Tween.Linear(halfLife)) {
				ager.MoveTo(0.0F, Time.deltaTime);
				yield return null;
			}

			Assert.That(initialValue * 0.5F, Is.EqualTo(ager.Value).Within(1.0F).Percent);
		}
	}
}
