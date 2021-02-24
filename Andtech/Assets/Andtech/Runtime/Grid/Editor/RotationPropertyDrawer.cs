#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Andtech {

	[CustomPropertyDrawer(typeof(Rotation))]
	public class RotationPropertyDrawer : PropertyDrawer {
		private int columnCount = 4;
		private int rowCount = 3;
		private float height = 32.0F;
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

		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			if (textures is null)
				textures = Resources.LoadAll<Texture2D>("Icons").Where(x => x.name.Contains("Arrow_")).OrderBy(x => x.name).ToArray();

			EditorGUI.BeginProperty(position, label, property);

			// Deserialize
			SerializedProperty matrixProperty = property.FindPropertyRelative("matrix");
			var m00 = matrixProperty.FindPropertyRelative("m00");
			var m01 = matrixProperty.FindPropertyRelative("m01");
			var m02 = matrixProperty.FindPropertyRelative("m02");
			var m10 = matrixProperty.FindPropertyRelative("m10");
			var m11 = matrixProperty.FindPropertyRelative("m11");
			var m12 = matrixProperty.FindPropertyRelative("m12");
			var m20 = matrixProperty.FindPropertyRelative("m20");
			var m21 = matrixProperty.FindPropertyRelative("m21");
			var m22 = matrixProperty.FindPropertyRelative("m22");
			var m = new Matrix3x3Byte(
				new Vector3Int(m00.intValue, m10.intValue, m20.intValue),
				new Vector3Int(m01.intValue, m11.intValue, m21.intValue),
				new Vector3Int(m02.intValue, m12.intValue, m22.intValue)
			);

			Vector3Int forward = m.GetColumn(2);
			Vector3Int output;

			var cnt = new GUIContent(label) { text = string.Format("{0} {1}", label.text, forward) };
			EditorGUI.PrefixLabel(position, cnt);

			output = DrawCustomGrid(position, m);

			if (output != forward) {
				Rotation rot = Rotation.LookRotation(output);
				m = rot.matrix;

				m00.intValue = m[0, 0];
				m01.intValue = m[0, 1];
				m02.intValue = m[0, 2];
				m10.intValue = m[1, 0];
				m11.intValue = m[1, 1];
				m12.intValue = m[1, 2];
				m20.intValue = m[2, 0];
				m21.intValue = m[2, 1];
				m22.intValue = m[2, 2];
			}

			EditorGUI.EndProperty();
		}

		private Vector3Int DrawCustomGrid(Rect position, Matrix3x3Byte m) {
			var forward = m.GetColumn(2);
			var output = forward;

			Rect newposition = position;
			newposition.y += headerHeight;

			for (int row = 0; row < 3; row++) {
				int rowSign = -IndexToSign(row);

				for (int col = 0; col < 3; col++) {
					int colSign = IndexToSign(col);

					bool horizontalMatch = colSign == forward.x;
					bool verticalMatch = rowSign == forward.z;
					bool shouldBeOn = horizontalMatch && verticalMatch;

					newposition.height = height;
					newposition.width = position.width / columnCount;

					if (Toggle(newposition, new GUIContent(textures[iconIndicesXZ[row, col]]), shouldBeOn)) {
						output.x = colSign;
						output.z = rowSign;
					}

					newposition.x += newposition.width;
				}

				var shouldBeOn2 = rowSign == forward.y;
				if (Toggle(newposition, new GUIContent(textures[iconIndicesY[row]]), shouldBeOn2))
					output.y = rowSign;

				newposition.x += newposition.width;

				// Finalize
				newposition.x = position.x;
				newposition.y += height;
			}

			return output;

			bool Toggle(Rect r, GUIContent lbl, bool isInteractable) {
				if (isInteractable) {
					GUI.Box(r, lbl, EditorStyles.centeredGreyMiniLabel);
					return false;
				}

				var result = GUI.Button(r, lbl);
				return result != isInteractable;
			}

			int IndexToSign(int index) {
				switch (index) {
					case 0:
						return -1;
					case 1:
						return 0;
					case 2:
						return 1;
				}

				return 0;
			}
		}

		public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
			return headerHeight + height * rowCount;
		}
	}
}
#endif
