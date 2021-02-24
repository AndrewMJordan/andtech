/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

namespace Andtech {
	/*
	[CustomPropertyDrawer(typeof(Direction))]
	public class DirectionPropertyDrawer : PropertyDrawer {
		private int columnCount = 3;
		private int rowCount = 3;
		private float height = 24.0F;
		private float headerHeight = 16.0F;

		private Texture2D[] textures;
		private string[,] labelsXZ = new string[,] {
		{ "Forward Left", "Forward", "Forward Right"},
		{ "Left", "Center", "Right" },
		{"Back Left", "Back", "Back Right" }
		};
		private string[] labelsY = new string[] { "Up", "Zero", "Down" };
		private int[,] iconIndicesXZ = new int[,] {
		{ 3, 2, 1},
		{ 4, 8, 0 },
		{5, 6, 7 }
		};
		private int[] iconIndicesY = new int[] { 2, 8, 6 };

		private Direction[] directionsX = new Direction[] { Direction.Left, Direction.Zero, Direction.Right };
		private Direction[] directionsZ = new Direction[] { Direction.Forward, Direction.Zero, Direction.Back };
		private Direction[] directionsY = new Direction[] { Direction.Up, Direction.Zero, Direction.Down };

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			if (textures is null)
				textures = Resources.LoadAll<Texture2D>("Icons").Where(x => x.name.Contains("Arrow_")).OrderBy(x => x.name).ToArray();

			EditorGUI.BeginProperty(position, label, property);

			// Deserialize
			Direction direction = (Direction)fieldInfo.GetValue(property.serializedObject.targetObject);

			EditorGUI.PrefixLabel(position, label);
			EditorGUILayout.HelpBox(direction.ToString(), MessageType.None);

			Direction output;
			output = DrawCustomGrid(position, direction);
			if (output != direction)
				Debug.Log(output);

			if (output != direction)
				property.intValue = (int)System.Convert.ChangeType(output, typeof(Direction));

			EditorGUI.EndProperty();
		}

		private Direction DrawCustomGrid(Rect position, Direction direction) {
			var Y = (Direction.Down | Direction.Up);
			var XZ = (Direction.Left | Direction.Right | Direction.Back | Direction.Forward);

			Rect newposition = position;
			newposition.y += headerHeight;

			var output = Direction.Zero;
			for (int row = 0; row < 3; row++) {
				var directionY = directionsY[row];

				for (int col = 0; col < 3; col++) {
					var directionXZ = directionsX[col] | directionsZ[row];
					var mask = directionXZ;

					bool shouldBeOn = (direction & ~Y).HasFlag(mask);

					newposition.height = height;
					newposition.width = position.width / columnCount;

					var result = Toggle(newposition, new GUIContent(textures[iconIndicesXZ[row, col]]), shouldBeOn);
					if (result)
						output |= directionXZ;

					if (result != shouldBeOn)
						Debug.Log(directionXZ);

					newposition.x += newposition.width;
				}
				newposition.x += newposition.width;

				// Finalize
				newposition.x = position.x;
				newposition.y += height;
			}

			return output;

			bool Toggle(Rect r, GUIContent lbl, bool isInteractable) {
				var result = GUI.Toggle(r, isInteractable, lbl, EditorStyles.toolbarButton);
				return result;
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			return headerHeight + height * rowCount;
		}
	}
		*/
}
