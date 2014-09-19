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
        //var list = Resources.FindObjectsOfTypeAll<AudioClip>();

        //foreach (AudioClip clip in list) {
        //    Debug.Log(":: " + clip.name);


        //    AudioSources.Add(clip);
        //    AddMaterialStepSound(clip.name, clip);
        //}


        DrawDefaultInspector();

        if (GUILayout.Button("Refresh Audio Sources")) {
            RefreshSources(target as AudioManager);
        }

        if (GUILayout.Button("Clear Audio Sources")) {
            ClearSources(target as AudioManager);
        }
    }

    private void RefreshSources(AudioManager manager)
    {
        string soundPath = Application.dataPath + "/Resources/Sound";

        manager.ClearSources();

        var fileList = Directory.GetFiles(soundPath, "*.ogg", SearchOption.AllDirectories);

        foreach (var fName in fileList) {
            var fInfo = new FileInfo(fName);

            if (manager.Verbose) {
                Debug.Log("Found: " + Relativize(fInfo));
            }

            string asset = Relativize(fInfo);
            AudioClip clip = Resources.Load<AudioClip>(asset);

            if (clip == null) {
                Debug.LogError("Failed to load asset: " + asset);
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
