using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using XNode;


//[CreateAssetMenu(fileName = "DialogEditorGraph", menuName = "DialogEditor/DialogueParagraph")]
public class DialogNodeGraph : NodeGraph
{
    [MenuItem("Dialog/CreateGraph")]
    private static void Aaaaa()
    {
        var exampleAsset = CreateInstance<DialogNodeGraph>();
        AssetDatabase.CreateAsset(exampleAsset, "Assets/ExampleAsset.asset");
        AssetDatabase.Refresh();
    }

}