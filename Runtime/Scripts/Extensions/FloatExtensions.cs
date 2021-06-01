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

    public static class FloatExtensions
    {

        public static void Snap(this ref float number, int divisions)
        {
            if (divisions < 1)
            {
                return;
            }

            number = Mathf.Round(number * divisions) / divisions;
        }
    }
}
