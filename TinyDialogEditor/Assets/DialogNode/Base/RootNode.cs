using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class RootNode : Node
{
    [Output(backingValue = ShowBackingValue.Never)] public bool NextDialog;

    /// <summary>
    /// 获取下一个节点
    /// </summary>
    /// <returns></returns>
    public DialogBaseNode GetNextDialog()
    {
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