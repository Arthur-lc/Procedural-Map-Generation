using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor (typeof(Chunk))]
public class EditorMapGeneration : Editor
{

    public override void OnInspectorGUI()
    {
        Chunk chunk = (Chunk)target;

        if (DrawDefaultInspector () && chunk.autoGenerate) {
            chunk.GenerateMap();
        }

        if (GUILayout.Button ("Generate")) {
            chunk.GenerateMap();
        }

        if (GUILayout.Button ("Save .PNG")) {
            chunk.savePNG();
        }
    }
}
