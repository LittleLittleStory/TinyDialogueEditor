using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class BranchNodeBase : DialogBaseNode
{
    [Output(dynamicPortList = true)] public List<bool> Branchs = new List<bool>();

    public DialogBaseNode GetNextDialog(int index)
    {
       string portName= "Branchs " + index;
        NodePort port = GetPort(portName);
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
}