//
// Klak - Utilities for creative coding with Unity
//
// Copyright (C) 2016 Keijiro Takahashi
using UnityEngine;
using UnityEditor;
using UnityEditor.Graphs;

namespace SimpleScript
{
    // Inspector GUI for the specialized node
    [CustomEditor(typeof(Node))]
    class NodeEditor : Editor
    {        
        public override void OnInspectorGUI()
        {
            GUILayout.Label("hey");
        }
    }
}
