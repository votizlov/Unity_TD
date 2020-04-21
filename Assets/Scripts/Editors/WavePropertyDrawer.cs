using UnityEditor;
using UnityEngine;

namespace Editors
{
    //   [CustomPropertyDrawer(typeof(Wave))]
    public class WavePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            Rect delayRect = new Rect(position.x, position.y, 30, position.height);
            Rect spawnTransformRect = new Rect(position.x + 35, position.y, 200, position.height);
            int c = 1;

            foreach (var enemyProp in property.FindPropertyRelative("enemies"))
            {
                Rect spawnedObjRect = new Rect(position.x, position.y + 35 * c, 200, position.height);
                EditorGUI.PropertyField(spawnedObjRect, (SerializedProperty) enemyProp, GUIContent.none);
                c++;
            }

            EditorGUI.PropertyField(delayRect, property.FindPropertyRelative("Delay"), GUIContent.none);
            EditorGUI.PropertyField(spawnTransformRect, property.FindPropertyRelative("spawnPoint"), GUIContent.none);


            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();
        }
    }
}