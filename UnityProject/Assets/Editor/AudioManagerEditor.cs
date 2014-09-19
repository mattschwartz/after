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
        AudioManager manager = target as AudioManager;
        DrawDefaultInspector();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Refresh")) {
            RefreshSources(manager);
        }

        if (GUILayout.Button("Clear")) {
            ClearSources(manager);
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Material Footstep Sounds");
        GUILayout.EndHorizontal();

        foreach (var key in manager.MaterialStepSounds.Keys) {
            foreach (var clip in manager.MaterialStepSounds[key]) {
                GUILayout.BeginHorizontal();
                GUILayout.Label(key);
                GUILayout.FlexibleSpace();
                EditorGUILayout.ObjectField(clip, typeof(AudioClip));
                GUILayout.EndHorizontal();
            }
        }
    }

    private void RefreshSources(AudioManager manager)
    {
        ClearSources(manager);

        // This is less capable and has issues sometimes...
        //if (EditorUserBuildSettings.activeBuildTarget == BuildTarget.WebPlayer) {
        //    foreach (var clip in Resources.FindObjectsOfTypeAll<AudioClip>()) {
        //        manager.AudioSources.Add(clip);
        //        AddMaterialStepSound(clip.name, clip);
        //    }

        //    Debug.Log("Added " + manager.AudioSources.Count + " files.");

        //    return;
        //}

        string soundPath = Application.dataPath + "/Resources/Sound";
        var fileList = Directory.GetFiles(soundPath, "*.ogg", SearchOption.AllDirectories);

        foreach (var fName in fileList) {
            var fInfo = new FileInfo(fName);

            if (manager.Verbose) {
                Debug.Log("Found: " + Relativize(fInfo));
            }

            string asset = Relativize(fInfo);
            AudioClip clip = Resources.Load<AudioClip>(asset);

            if (clip == null) {
                Debug.LogWarning("Failed to load asset: " + asset);
            }

            manager.AudioSources.Add(clip);
            AddMaterialStepSound(manager, fInfo.Name, clip);
        }
    }

    private void ClearSources(AudioManager manager)
    {
        manager.ClearSources();
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

    public void AddMaterialStepSound(AudioManager manager, string clipName, AudioClip clip)
    {
        foreach (var material in manager.MaterialTypes) {
            if (clipName.Contains(material)) {

                if (!manager.MaterialStepSounds.ContainsKey(material)) {
                    manager.MaterialStepSounds[material] = new List<AudioClip>();
                }

                manager.MaterialStepSounds[material].Add(clip);
            }
        }
    }
}
