using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class DialogNodeBase : Node
{
    private string dialogGuid;
    [Input(backingValue = ShowBackingValue.Never)] public bool LastDialog;
    [Output(backingValue = ShowBackingValue.Never)] public bool NextDialog;
    public string DialogueName;
    public bool canReturn = true;

    protected override void Init()
    {
        base.Init();
        if (string.IsNullOrEmpty(dialogGuid))
            dialogGuid = System.Guid.NewGuid().ToString();
    }
}