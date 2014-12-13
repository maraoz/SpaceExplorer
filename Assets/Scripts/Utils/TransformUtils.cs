using UnityEngine;
using System.Collections;

public class TransformUtils 
{
	public static void Bind(Transform src, Transform target, bool parent)
	{
		src.position = target.position;
		src.rotation = target.rotation;
		src.localScale = target.localScale;

		if(parent)
			src.parent = target;
	}
}