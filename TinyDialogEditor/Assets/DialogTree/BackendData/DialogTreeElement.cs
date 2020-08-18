using System;
using UnityEngine;
using Random = UnityEngine.Random;


[Serializable]
public class DialogTreeElement : TreeElement
{
    public DialogNodeGraph DialogNodeGraph;
    public string Note = "";

    public DialogTreeElement(string name, int depth, int id) : base(name, depth, id)
    {

    }
}
