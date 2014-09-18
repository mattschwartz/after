using UnityEngine;
using UnityEditor;
using System.Collections;
using After.Audio;

[CustomEditor(typeof(AudioManager))]
public class AudioManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        AudioManager myScript = (AudioManager)target;
        if(GUILayout.Button("Refresh Audio Sources")) {
            myScript.RefreshSources();
        }

        if (GUILayout.Button("Clear Audio Sources")) {
        	myScript.ClearSources();
        }
    }
}