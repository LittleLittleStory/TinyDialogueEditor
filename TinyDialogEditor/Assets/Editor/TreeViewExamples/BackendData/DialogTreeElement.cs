using System;
using UnityEngine;
using Random = UnityEngine.Random;


namespace UnityEditor.TreeViewExamples
{

	[Serializable]
	internal class DialogTreeElement : TreeElement
	{
		public DialogNodeGraph dialogNodeGraph;
		public string text = "";

		public DialogTreeElement (string name, int depth, int id) : base (name, depth, id)
		{

		}
	}
}
