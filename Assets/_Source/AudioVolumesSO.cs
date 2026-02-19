using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioVolumesSO", menuName = "Scriptable Objects/AudioVolumesSO")]
public class AudioVolumesSO : ScriptableObject
{
    internal bool IsDescriptionShown;
    internal bool IsListShown;

    [field:SerializeField]
    internal AudiosType audioType;

    [field:SerializeField]
    public string SOID { get; private set; } = "test";
    [field:SerializeField]
    public List<AudioVolume> AudioVolumes{ get; private set; }  = new();
    [field:SerializeField]
    public Dictionary<AudiosType, string> Descriptions{ get; internal set; }  = new()
    {
        [AudiosType.Neutral] = ":|",
        [AudiosType.Friendly] = ":)",
        [AudiosType.Hostile] = ">:(",
    };
    [TextArea(0, 25)]
    public string Description{ get; internal set; } 
}
[System.Serializable]
public class AudioVolume
{
    [SerializeField]
    public AudioClip audioClip;
    [SerializeField, Range(0, 1)]
    public float volume = 1;
}
public enum AudiosType
{
    Neutral,
    Friendly,
    Hostile,
}
[CustomEditor(typeof(AudioVolumesSO))]
[CanEditMultipleObjects]
public class CustomVolumeEditor : Editor
{
    private AudioVolumesSO script;
    private SerializedProperty _listProperty;
    private SerializedProperty _idProperty;
    private void OnEnable()
    {
        script = (AudioVolumesSO)target;
        _idProperty = serializedObject.FindProperty(GetBackingName(nameof(script.SOID)));
        _listProperty = serializedObject.FindProperty(GetBackingName(nameof(script.AudioVolumes)));
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(_idProperty);

        script.audioType = (AudiosType)EditorGUILayout.EnumPopup("Audios Type: ", script.audioType); // have to be like this.

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Show Description"))
        {
            script.IsDescriptionShown = true;
            script.IsListShown = false;
        }
        if (GUILayout.Button("Show Volumes List"))
        {
            script.IsDescriptionShown = false;
            script.IsListShown = true;
        }
        if (GUILayout.Button("Close Tabs"))
        {
            script.IsDescriptionShown = false;
            script.IsListShown = false;
        }
        EditorGUILayout.EndHorizontal();
        if (script.IsDescriptionShown)
        {

            EditorGUILayout.LabelField("Description:");
            if (script != null) // no other variants, as this have to be setted
            {
                if (script.Descriptions.ContainsKey(script.audioType))
                {
                    GUIStyle style = EditorStyles.textArea;
                    script.Descriptions[script.audioType] = GUILayout.TextArea(script.Descriptions[script.audioType],25, style);
                }
            }
        }
        if (script.IsListShown)
        {
            EditorGUILayout.PropertyField(_listProperty);
        }
        serializedObject.ApplyModifiedProperties();
    }
    private string GetBackingName(string name)=>$"<{name}>k__BackingField";
}