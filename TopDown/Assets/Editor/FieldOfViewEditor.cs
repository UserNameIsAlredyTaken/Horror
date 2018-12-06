using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor {
    
    private void OnSceneGUI()
    {
        FieldOfView fow = (FieldOfView) target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.up, 360, fow._viewRadius); //draw view radius 
        Vector3 viewAngleA = fow.DirFromAngle(-fow._viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow._viewAngle / 2, false);
        
        //draw view angles
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow._viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow._viewRadius);

        //draw line to visible enemies
        Handles.color = Color.red;
        foreach (Transform visibleEnemy in fow._visibleEnemies)
        {
            Handles.DrawLine(fow.transform.position, visibleEnemy.position);
        }
    }
}
