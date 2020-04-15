using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEventsFramework;

[CustomEditor (typeof(StateController), true)]
public class StateControllerEditor : Editor {

 	public override void OnInspectorGUI() {

		StateController controller = (StateController)target;
 		State currentState = controller.currentState;

		
		serializedObject.Update();
		
		EditorGUILayout.PropertyField(serializedObject.FindProperty("database"));
		EditorGUILayout.PropertyField(serializedObject.FindProperty("remainState"));

		EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

		EditorGUILayout.PropertyField(serializedObject.FindProperty("currentState"));
		
		if (currentState != null) {
			SerializedObject stateSO = new SerializedObject(currentState);
			SerializedProperty actions = stateSO.FindProperty("actions");
			SerializedProperty logActions = stateSO.FindProperty("logActions");
			SerializedProperty archiveActions = stateSO.FindProperty("archiveActions");
			
			EditorArray.ShowActions(actions, logActions, archiveActions, controller, EditorArrayOption.NoElementLabels);

		}

		EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);

		EditorGUILayout.PropertyField(serializedObject.FindProperty("debugMode"));

		serializedObject.ApplyModifiedProperties(); 

	}

}