using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NoiseDebugger))]
public class NoiseDebuggerEditor : Editor {
    
    public override void OnInspectorGUI() {
        NoiseDebugger noiseDebugger = (NoiseDebugger)target;

        if (DrawDefaultInspector()) {
            if (noiseDebugger.autoUpdate) {
                noiseDebugger.GenerateDebugNoise();
            }
        }

        if (GUILayout.Button("Generate Map")) {
            noiseDebugger.GenerateDebugNoise();
        }
    }
}
