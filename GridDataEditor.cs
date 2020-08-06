using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Unity3DTileGrid;

[CustomEditor(typeof(GridData))]
public class GridDataEditor : Editor {

    public override void OnInspectorGUI() {
        GridData gridData = (GridData)target;
        DrawDefaultInspector();

        if (GUILayout.Button("Save Grid Data")) {
            gridData.SaveGridData();
        }
        if (GUILayout.Button("Load Grid Data")) {
            gridData.LoadGridData();
        }
    }
}
