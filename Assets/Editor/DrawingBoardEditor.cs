using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DrawingBoard))]
public class DrawingBoardEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // Draws the default convertor

        DrawingBoard script = (DrawingBoard)target;

        if (GUILayout.Button("Clear board"))
        {
            script.GenerateTexture();
        }
    }
}
