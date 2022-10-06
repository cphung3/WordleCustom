using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameFlowManager))]
public class GameFlowManagerEditor : Editor
{
    string m_spoiler = null;

    GameFlowManager m_manager = null;

    private void OnEnable()
    {
        m_manager = (GameFlowManager)target;
        m_manager.Restarted += OnRestarted;
    }

    private void OnRestarted()
    {
        m_spoiler = null;
        Repaint();
    }

    private void OnDisable()
    {
        m_manager.Restarted -= OnRestarted;
        m_manager = null;
    }

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
                    m_spoiler = m_manager.GetWord();
                }
            }
            else
            {
                GUILayout.Label(m_spoiler, EditorStyles.boldLabel);
            }
        }
    }
}
