using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class SentenceNode : DialogNodeBase
{
    public string CharacterName;
    [TextArea(3, 5)]
    public string Sentence;

    protected override void Init()
    {
        base.Init();
    }

    public override object GetValue(NodePort port) {
		return null; // Replace this
	}
}