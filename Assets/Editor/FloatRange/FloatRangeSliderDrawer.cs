using System;
using StackFall;
using StackFall.Ranges.Float;
using UnityEditor;
using UnityEngine;

namespace Editor.FloatRange
{
	[CustomPropertyDrawer(typeof(FloatRangeSliderAttribute))]
	public class FloatRangeSliderDrawer : PropertyDrawer
	{
		private const string MinProperty = "_min";
		private const string MaxProperty = "_max";
		private const string TwoDigitsFormat = "F";
		
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			var originalIndentLevel = EditorGUI.indentLevel;
			
			EditorGUI.BeginProperty(position, label, property);
			
			position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
			EditorGUI.indentLevel = 0;
			
			var minProperty = property.FindPropertyRelative(MinProperty);
			var maxProperty = property.FindPropertyRelative(MaxProperty);
			var minValue = minProperty.floatValue;
			var maxValue = maxProperty.floatValue;
			var fieldWidth = position.width / 4f - 12f;
			var sliderWidth = position.width / 2f;
			
			position.width = fieldWidth;
			minValue = (float) Convert.ToDouble(EditorGUI.TextField(position, minValue.ToString(TwoDigitsFormat)));
			position.x += fieldWidth + 12f;
			
			position.width = sliderWidth + 7f;
			position.xMin -= 6.5f;
			var limit = attribute as FloatRangeSliderAttribute;
			EditorGUI.MinMaxSlider(position, ref minValue, ref maxValue, limit!.Min, limit.Max);
			position.x += sliderWidth + 18f;
			position.width = fieldWidth;
			maxValue = (float) Convert.ToDouble(EditorGUI.TextField(position, maxValue.ToString(TwoDigitsFormat)));
			
			if (minValue < limit.Min) 
				minValue = limit.Min;

			if (maxValue < minValue)
				maxValue = minValue;
			else if (maxValue > limit.Max) 
				maxValue = limit.Max;

			minProperty.floatValue = minValue;
			maxProperty.floatValue = maxValue;
			
			EditorGUI.EndProperty();
			
			EditorGUI.indentLevel = originalIndentLevel;
		}
	}
}