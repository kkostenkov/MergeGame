using System;
using Merge.Session;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    [SerializeField]
    private SessionDirector session;

    public void OnGUI()
    {
        if (!session)
        {
            return;
        }
        
        GUILayout.BeginVertical();
        {
            if (GUILayout.Button("Restart"))
            {
                session.Restart();
            }
            if (GUILayout.Button("Spawn smth somewhere"))
            {
                
            }
            if (GUILayout.Button("Clear"))
            {
                
            }
        }
        GUILayout.EndVertical();
    }
}
