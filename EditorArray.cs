using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEventsFramework;
using System;

public static class EditorArray {

	public static void ShowActions(SerializedProperty actionsArray, SerializedProperty logArray, SerializedProperty archiveArray, StateController controller, EditorArrayOption options = EditorArrayOption.Default) {
		bool
			showArrayLabel = (options & EditorArrayOption.ArrayLabel) != 0,
			showArraySize = (options & EditorArrayOption.ArraySize) != 0;
			

		if (showArrayLabel) {
			EditorGUILayout.PropertyField(actionsArray);
			EditorGUI.indentLevel += 1;
		} 
		if (!showArrayLabel || actionsArray.isExpanded) {
			if (showArraySize) {
				//EditorGUILayout.PropertyField(actionsArray.FindPropertyRelative("Array.size"));
				EditorGUILayout.PropertyField(actionsArray.FindPropertyRelative("Array.size"));
			}
			ShowElements(actionsArray, logArray, archiveArray, options, controller);
			
		}
		if (showArrayLabel) {
			EditorGUI.indentLevel -= 1;
		}
	}

	private static GUIContent callActionButton = new GUIContent("Act", "Call Action");

	private static GUILayoutOption miniButtonWidth = GUILayout.Width(30f);

	private static void ShowElements(SerializedProperty actionsArray, SerializedProperty logArray, SerializedProperty archiveArray, EditorArrayOption options, StateController controller) {
		bool showElementLabels = (options & EditorArrayOption.ElementLabels) != 0,
		showButtons = (options & EditorArrayOption.Buttons) != 0;

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Action", EditorStyles.boldLabel);
		EditorGUILayout.LabelField("Arch", EditorStyles.boldLabel, GUILayout.Width(35) );
		EditorGUILayout.LabelField("Log", EditorStyles.boldLabel, GUILayout.Width(30));
		EditorGUILayout.LabelField("", EditorStyles.boldLabel, GUILayout.Width(30));
		
		EditorGUILayout.EndHorizontal();
		for (int i = 0; i < actionsArray.arraySize; i++) {
			if (showButtons) {
				
				EditorGUILayout.BeginHorizontal();
			}
			if (showElementLabels) {
				EditorGUILayout.PropertyField(actionsArray.GetArrayElementAtIndex(i),GUIContent.none);
				EditorGUILayout.PropertyField(archiveArray.GetArrayElementAtIndex(i),GUIContent.none, GUILayout.Width(20));
				EditorGUILayout.PropertyField(logArray.GetArrayElementAtIndex(i),GUIContent.none, GUILayout.Width(20));
			} else {
				EditorGUILayout.PropertyField(actionsArray.GetArrayElementAtIndex(i), GUIContent.none);
				EditorGUILayout.PropertyField(archiveArray.GetArrayElementAtIndex(i), GUIContent.none, GUILayout.Width(20));
				EditorGUILayout.PropertyField(logArray.GetArrayElementAtIndex(i), GUIContent.none, GUILayout.Width(20));
			}
			if (showButtons) {
				ShowButtons(actionsArray, i, controller);
				EditorGUILayout.EndHorizontal();
			}
		}
	}

/* 	public static void ShowPlaybooks(SerializedObject playbookSO, Playbook playbook) {
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Playbook", EditorStyles.boldLabel);
		EditorGUILayout.EndHorizontal();

		if (playbooks.arraySize > 0) {
			for (int i = 0; i < playbooks.arraySize; i++) {
				EditorGUILayout.BeginHorizontal();

				EditorGUILayout.PropertyField(playbooks.GetArrayElementAtIndex(i), GUIContent.none);
				if (GUILayout.Button(callActionButton, miniButtonWidth)) {
					//StateController state = (StateController)target;
					playbook.Play();
				}

				EditorGUILayout.EndHorizontal();
			}
		}
	} */

	private static void ShowButtons (SerializedProperty actionsArray, int index, StateController controller) {
		if (GUILayout.Button(callActionButton, miniButtonWidth)) {
			//StateController state = (StateController)target;
			controller.currentState.CallActionAtIndex(index, controller);
		}
	}
}

[Flags]
public enum EditorArrayOption {
	None = 0,
	ArraySize = 1,
	ArrayLabel = 2,
	ElementLabels = 4,
	Buttons = 8,
	
	Default = ArraySize | ArrayLabel | ElementLabels,
	
	NoElementLabels = Buttons,

	All = Default | Buttons
}
