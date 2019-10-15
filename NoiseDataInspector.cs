using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NoiseData))]
public class NoiseDataInspector : Editor {

    NoiseData noiseData;

    void OnEnable() {
        noiseData = target as NoiseData;
        Undo.undoRedoPerformed += RefreshNoise;
    }

    void OnDisable() {
        Undo.undoRedoPerformed -= RefreshNoise;
    }

    void RefreshNoise() {
        if (Application.isPlaying) {
            noiseData.RedrawMap();
        }
    }

    public override void OnInspectorGUI () {
        EditorGUI.BeginChangeCheck();
        DrawDefaultInspector();
        if (EditorGUI.EndChangeCheck()) {
            RefreshNoise();
        }
    }
}