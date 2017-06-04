using System;
using UnityEditor;
using UnityEngine;
using UnityEditor.Graphs;
using System.Collections.Generic;

namespace SimpleScript
{
    public class SimpleGraphEditorWindow : EditorWindow
    {
        private static SimpleGraphEditorWindow sGraphEditorWindow;
        private static Graph sStateMachineGraph;

        private static SimpleGraph stateMachineGraphGUI;

        [MenuItem("Window/SimpleScript/Graph")]
        public static void OpenWindow()
        {
            sGraphEditorWindow = GetWindow <SimpleGraphEditorWindow>();

            sStateMachineGraph = ScriptableObject.CreateInstance<Graph>();
            sStateMachineGraph.hideFlags = HideFlags.HideAndDontSave;

            //create new node
            Node node = ScriptableObject.CreateInstance<Node>();
            node.title = "mile2";
            node.position = new Rect(400, 34, 300, 200);
            
            node.AddInputSlot("input");
            Slot start = node.AddOutputSlot("output");
            node.AddProperty(new Property(typeof(System.Int32), "integer"));
            sStateMachineGraph.AddNode(node);

            //create new node
            Node node2 = ScriptableObject.CreateInstance<Node>();
            node2.title = "mile";
            node2.position = new Rect(0, 0, 300, 200);

            Slot end = node2.AddInputSlot("input");
            node2.AddOutputSlot("output");
            node2.AddProperty(new Property(typeof(System.Int32), "integer"));
            sStateMachineGraph.AddNode(node2);

            //create edge
            sStateMachineGraph.Connect(start, end);

            stateMachineGraphGUI = ScriptableObject.CreateInstance<SimpleGraph>();
            stateMachineGraphGUI.graph = sStateMachineGraph;
        }

        void OnGUI()
        {
            if (sGraphEditorWindow && stateMachineGraphGUI != null)
            {
                stateMachineGraphGUI.BeginGraphGUI(sGraphEditorWindow, new Rect(0, 0, sGraphEditorWindow.position.width, sGraphEditorWindow.position.height));
                stateMachineGraphGUI.OnGraphGUI();
                
                stateMachineGraphGUI.EndGraphGUI();

            }
        }
    }
}