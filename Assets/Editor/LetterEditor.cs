using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Letter))]
public class LetterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(Application.isPlaying)
        {
            GUILayout.Space(20f);

            if(GUILayout.Button("Enter Letter"))
            {
                ((Letter)target).EnterLetter('C');
            }
            if(GUILayout.Button("Delete Letter"))
            {
                ((Letter)target).DeleteLeter();
            }
            if(GUILayout.Button("Shake"))
            {
                ((Letter)target).Shake();
            }            
            if(GUILayout.Button("Correct"))
            {
                ((Letter)target).SetState(LetterState.Correct);
            }
            if(GUILayout.Button("Incorrect"))
            {
                ((Letter)target).SetState(LetterState.Incorrect);
            }
            if(GUILayout.Button("WrongLoc"))
            {
                ((Letter)target).SetState(LetterState.WrongLocation);
            }
        }
    }
}
