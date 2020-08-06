using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GamePerformanceData))]
public class GamePerformanceDataEditor : Editor {

    public override void OnInspectorGUI() {
        GamePerformanceData gamePerformanceData = (GamePerformanceData)target;
        DrawDefaultInspector();

        if (GUILayout.Button("Get Map Data")) {
            gamePerformanceData.GetMapData();
            gamePerformanceData.GetMapTimes();
        }
    }
}
