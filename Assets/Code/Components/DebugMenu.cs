using System;
using Merge.Session;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    [SerializeField]
    private SessionDirector session;

    private float elapsed;

    public void Update()
    {
        elapsed += Time.deltaTime;
    }

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
                elapsed = 0;
            }
            GUILayout.TextArea($"Elapsed: {elapsed:0.00}");
        }
        GUILayout.EndVertical();
    }
}
