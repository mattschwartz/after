using UnityEngine;
using System.Collections;
using After.Audio;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

[CustomEditor(typeof(AudioManager))]
public class AudioManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Load")) {
            RefreshSources();
        }

        if (GUILayout.Button("Clear")) {
            foreach (var clip in Resources.FindObjectsOfTypeAll<AudioClip>()) {
                Resources.UnloadAsset(clip);
            }
        }
        GUILayout.EndHorizontal();
    }

    private void RefreshSources()
    {
        string soundPath = Application.dataPath + "/Resources/Sound";
        var fileList = Directory.GetFiles(soundPath, "*.ogg", SearchOption.AllDirectories);

        foreach (var fName in fileList) {
            var fInfo = new FileInfo(fName);

            Debug.Log("Found: " + Relativize(fInfo));

            string asset = Relativize(fInfo);
            AudioClip clip = Resources.Load<AudioClip>(asset);

            if (clip == null) {
                Debug.LogWarning("Failed to load asset: " + asset);
            }
        }
    }

    private string Relativize(FileInfo fInfo)
    {
        int start = fInfo.FullName.IndexOf("Sound");
        int end = fInfo.FullName.IndexOf(".") - start;

        if (start < 0 || end < 0) {
            return fInfo.FullName;
        }

        return fInfo.FullName.Substring(start, end).Replace(@"\", "/");
    }

    //public void AddMaterialStepSound(AudioManager manager, string clipName, AudioClip clip)
    //{
    //    foreach (var material in manager.MaterialTypes) {
    //        if (clipName.Contains(material)) {

    //            if (!manager.MaterialStepSounds.ContainsKey(material)) {
    //                manager.MaterialStepSounds[material] = new List<AudioClip>();
    //            }

    //            manager.MaterialStepSounds[material].Add(clip);
    //        }
    //    }
    //}
}
