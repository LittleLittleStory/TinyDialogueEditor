using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class Test : MonoBehaviour
{
    public DialogNodeGraph NodeGraph;
    private RootNode rootNode;
    private DialogBaseNode curNode;
    void Start()
    {
        rootNode = NodeGraph.GetDialogRoot();
        if (null == rootNode)
            return;
        curNode = rootNode.GetNextDialog();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (null == curNode)
                return;
            if (curNode is BranchNodeBase)
            {
                BranchNodeBase branchNode = curNode as BranchNodeBase;
                branchNode.ReadNode();
                curNode = branchNode.GetNextDialog(0);
            }
            else
            {
                curNode.ReadNode();
                curNode = curNode.GetNextDialog();
            }
        }
    }
}
