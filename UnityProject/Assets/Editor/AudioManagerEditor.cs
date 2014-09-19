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

        if (GUILayout.Button("Refresh Audio Sources")) {
            RefreshSources();
        }

        if (GUILayout.Button("Clear Audio Sources")) {
            ClearSources();
        }
    }

    private static void RefreshSources()
    {
        string soundPath = Application.dataPath + "/Resources/Sound";

        AudioManager.ClearSources();

        var fileList = Directory.GetFiles(soundPath, "*.ogg", SearchOption.AllDirectories);

        foreach (var fName in fileList) {
            var fInfo = new FileInfo(fName);

            if (AudioManager.Verbose) {
                Debug.Log("Found: " + Relativize(fInfo));
            }

            string asset = Relativize(fInfo);
            AudioClip clip = Resources.Load<AudioClip>(asset);

            if (clip == null) {
                Debug.LogError("Failed to load asset: " + asset);
            }

            AudioManager.AudioSources.Add(clip);
            AddMaterialStepSound(fInfo.Name, clip);
        }
    }

    private static void ClearSources()
    {
        AudioManager.ClearSources();
    }

    private static string Relativize(FileInfo fInfo)
    {
        int start = fInfo.FullName.IndexOf("Sound");
        int end = fInfo.FullName.IndexOf(".") - start;

        if (start < 0 || end < 0) {
            return fInfo.FullName;
        }

        return fInfo.FullName.Substring(start, end).Replace(@"\", "/");
    }

    public static void AddMaterialStepSound(string clipName, AudioClip clip)
    {
        foreach (var material in AudioManager.MaterialTypes) {
            if (clipName.Contains(material)) {

                if (!AudioManager.MaterialStepSounds.ContainsKey(material)) {
                    AudioManager.MaterialStepSounds[material] = new List<AudioClip>();
                }

                AudioManager.MaterialStepSounds[material].Add(clip);
            }
        }
    }
}
