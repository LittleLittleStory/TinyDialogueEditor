using UnityEditor;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace Dialogue
{
    [CustomNodeEditor(typeof(SentenceBranchNode))]
    public class SentenceBranchEditor : BarchBaseEditor
    {
        public override void OnBodyGUI()
        {
            base.OnBodyGUI();

            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("CharacterName"), new GUIContent("Character Name"));
            NodeEditorGUILayout.PropertyField(serializedObject.FindProperty("Sentence"), new GUIContent("Sentence"));

            GUILayout.Space(5);

            if (GUILayout.Button("OpenSentenceEdiot")) Debug.Log("OpenEditor");
        }
    }
}