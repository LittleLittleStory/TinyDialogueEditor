using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace XNodeEditor
{
    [CustomNodeEditor(typeof(DialogBaseNode))]
    public class DialogBaseNodeEditor : NodeEditor
    {
        public override void OnHeaderGUI()
        {
            DialogBaseNode node = target as DialogBaseNode;
            DialogNodeGraph graph = node.graph as DialogNodeGraph;
            node.name = node.DialogueName;
            GUILayout.Label(node.DialogueName, NodeEditorResources.styles.nodeHeader, GUILayout.Height(30));
            GUI.color = Color.white;
        }
    }
}