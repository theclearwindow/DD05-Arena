using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fow = (FieldOfView)target;
        Handles.color = Color.green;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.visionRange);
        Vector3 viewAngleA = fow.DirFromAngle(-fow.FOV, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.FOV, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.visionRange);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.visionRange);

        /*
        Handles.color = Color.red;
        foreach (Transform visableTarget in fow.others)
        {
            Handles.DrawLine(fow.transform.position, visableTarget.position);      
        }
        */
    }
}