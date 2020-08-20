using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class SentenceNode : DialogBaseNode
{
    public string CharacterName;
    [TextArea(3, 5)]
    public string Sentence;

    protected override void Init()
    {
        base.Init();
    }

    public override object GetValue(NodePort port)
    {
        return Sentence;
    }

    public override void ReadNode()
    {
        Debug.Log(GetValue(GetPort("Sentence")));
    }
}