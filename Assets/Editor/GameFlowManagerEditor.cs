using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameFlowManager))]
public class GameFlowManagerEditor : Editor
{
    string m_spoiler = null;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (Application.isPlaying)
        {
            GUILayout.Space(20f);

            if(string.IsNullOrEmpty(m_spoiler))
            {
                if(GUILayout.Button("Spoiler"))
                {
                    m_spoiler = ((GameFlowManager)target).GetWord();
                }
            }
            else
            {
                GUILayout.Label(m_spoiler, EditorStyles.boldLabel);
            }
        }
    }
}
