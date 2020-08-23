using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class DialogBaseNode : Node
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

    /// <summary>
    /// 这是用户读取节点的接口
    /// </summary>
    public abstract void ReadNode();

    /// <summary>
    /// 得到上一个节点
    /// </summary>
    /// <returns></returns>
    public DialogBaseNode GetLastDialog()
    {
        NodePort port = GetPort("LastDialog");
        if (null != port)
        {
            if (port.Connection == null)
                return null;
            if (port.Connection.node == null)
                return null;
            if (port.Connection.node is DialogBaseNode)
                return (DialogBaseNode)port.Connection.node;
            return null;
        }
        return null;
    }

    /// <summary>
    /// 获取下一个节点
    /// </summary>
    /// <returns></returns>
    public DialogBaseNode GetNextDialog()
    {
        if (this is BranchNodeBase)
        {
            Debug.LogError("该节点是个分支，请不要用该接口");
            return null;
        }
        NodePort nextPort = GetPort("NextDialog");
        if (null != nextPort)
        {
            if (nextPort.Connection == null)
                return null;
            if (nextPort.Connection.node == null)
                return null;
            if (nextPort.Connection.node is DialogBaseNode)
                return (DialogBaseNode)nextPort.Connection.node;
            return null;
        }
        return null;
    }
}