//using UnityEditor;
//using UnityEngine;
//using XNode;
//using XNodeEditor;

//namespace Dialogue {
//    [CustomNodeEditor(typeof(SentenceNode))]
//    public class SentenceNodeEditor : NodeEditor {

//        public override void OnBodyGUI() {
//            serializedObject.Update();

//            SentenceNode node = target as SentenceNode;

//            if (node.answers.Count == 0) {
//                GUILayout.BeginHorizontal();
//                NodeEditorGUILayout.PortField(GUIContent.none, target.GetInputPort("LastDialog"), GUILayout.MinWidth(0));
//                NodeEditorGUILayout.PortField(GUIContent.none, target.GetOutputPort("NextDialog"), GUILayout.MinWidth(0));
//                GUILayout.EndHorizontal();
//            } else {
//                NodeEditorGUILayout.PortField(GUIContent.none, target.GetInputPort("LastDialog"));
//            }
//            GUILayout.Space(-30);

//            NodeEditorGUILayout.DynamicPortList("answers", typeof(DialogueBaseNode), serializedObject, NodePort.IO.Output, Node.ConnectionType.Override);

//            serializedObject.ApplyModifiedProperties();
//        }

//        public override int GetWidth() {
//            return 300;
//        }
//    }
//}