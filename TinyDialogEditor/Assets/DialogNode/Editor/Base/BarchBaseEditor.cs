using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace Dialogue
{
    [CustomNodeEditor(typeof(BranchNodeBase))]
    public class BarchBaseEditor : DialogBaseNodeEditor
    {
        public override void OnBodyGUI()
        {
            BranchNodeBase node = target as BranchNodeBase;
            DialogNodeGraph graph = node.graph as DialogNodeGraph;

            NodeEditorGUILayout.PortField(new GUIContent("Last Dialog"), target.GetInputPort("LastDialog"), GUILayout.MinWidth(0));

            if (node.Branchs.Count == 0)
            {
                GUILayout.BeginHorizontal();
                NodeEditorGUILayout.PortField(new GUIContent("Next Dialog"), target.GetOutputPort("NextDialog"), GUILayout.MinWidth(0));
                GUILayout.EndHorizontal();
            }

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("DialogueName"), new GUIContent("Dialogue Name"));
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("canReturn"), new GUIContent("Can Return"));

            GUILayout.Space(5);

            NodeEditorGUILayout.DynamicPortList("Branchs", typeof(DialogBaseNode), serializedObject, NodePort.IO.Output, Node.ConnectionType.Override);
        }

        public override int GetWidth()
        {
            return 300;
        }
    }
}