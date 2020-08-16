using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace XNodeEditor
{
    [CustomNodeEditor(typeof(DialogNodeBase))]
    public class SentenceNodeEditor : NodeEditor
    {
        public override void OnHeaderGUI()
        {
            DialogNodeBase node = target as DialogNodeBase;
            DialogNodeGraph graph = node.graph as DialogNodeGraph;
            node.name = node.DialogueName;
            GUILayout.Label(node.DialogueName, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
            GUI.color = Color.white;
        }

        public override void OnBodyGUI()
        {
            base.OnBodyGUI();
            DialogNodeBase node = target as DialogNodeBase;
            DialogNodeGraph graph = node.graph as DialogNodeGraph;
            if (GUILayout.Button("OpenSentenceEdiot"))Debug.Log("OpenEditor");
        }
    }
}