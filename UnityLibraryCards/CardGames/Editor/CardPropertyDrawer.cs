using UnityEditor;
using UnityEngine;
using System;

using UnityLibraryCards;  
[CustomPropertyDrawer(typeof(Card))]
    public class CardPropertyDrawer : PropertyDrawer
    {
        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Using BeginProperty / EndProperty on the parent property means that
            // __prefab__ override logic works on the entire property.
            EditorGUI.BeginProperty(position, label, property);

            // Draw label
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

            // Don't make child fields be indented
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            // Calculate rects
            var faceRect = new Rect(position.x, position.y, 40, position.height);
            var suitField = new Rect(position.x + 42, position.y, 40, position.height);
            var nameRect = new Rect(position.x + 86, position.y, position.width - 90, position.height);

            // Draw fields - passs GUIContent.none to each so they are drawn without labels
            EditorGUI.PropertyField(suitField, property.FindPropertyRelative("suit"), GUIContent.none);
            EditorGUI.PropertyField(faceRect, property.FindPropertyRelative("face"), GUIContent.none);
            EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"), GUIContent.none);
            // var spriteRect = new Rect(position.x, position.y, position.width, position.height);
            //  property.objectReferenceValue = EditorGUI.ObjectField(spriteRect, property.objectReferenceValue, typeof(Texture2D), false);
            // EditorGUI.PropertyField(spriteRect, property.FindPropertyRelative("cardPrefab"), GUIContent.none);
            // Set indent back to what it was
            EditorGUI.indentLevel = indent;

            EditorGUI.EndProperty();


        }
    }

  
