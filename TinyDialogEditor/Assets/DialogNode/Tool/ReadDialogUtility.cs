using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public static class ReadDialogUtility
{
    public static RootNode GetDialogRoot(this DialogNodeGraph dialogNodeGraph)
    {
        foreach (Node item in dialogNodeGraph.nodes)
        {
            if (item is RootNode) 
                return (RootNode)item;
        }
        return null;
    }
}
