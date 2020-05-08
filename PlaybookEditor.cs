using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Playbook))]
public class PlaybookEditor : Editor {



    public override void OnInspectorGUI () {
        DrawDefaultInspector();
        if (GUILayout.Button("Play")) {
            Playbook pb = target as Playbook;
            pb.Play();
        }
         
    }
}
