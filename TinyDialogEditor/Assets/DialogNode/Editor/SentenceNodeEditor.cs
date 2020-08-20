using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace XNodeEditor
{
    [CustomNodeEditor(typeof(SentenceNode))]
    public class SentenceNodeEditor : DialogBaseNodeEditor
    {
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();
            SentenceNode node = target as SentenceNode;
            DialogNodeGraph graph = node.graph as DialogNodeGraph;
            if (GUILayout.Button("OpenSentenceEdiot"))Debug.Log("OpenEditor");
        }
    }
}