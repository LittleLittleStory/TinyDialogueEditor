using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class RootNode : Node
{
    [Output(backingValue = ShowBackingValue.Never)] public bool NextDialog;
}