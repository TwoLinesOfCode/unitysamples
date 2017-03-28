using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundTrigger : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D coll)
	{
		switch (coll.gameObject.tag)
		{
			case "playerTag":
				BringPlayerBackToScreen(coll);
				break;
			case "bullet":
				DestroyExtraObject(coll);
				break;
			case "enemy":
				DestroyExtraObject(coll);
				break;
		}
		
	}

	private void DestroyExtraObject(Collider2D coll)
	{
		DestroyObject(coll.gameObject);
	}

	private static void BringPlayerBackToScreen(Collider2D coll)
	{
		var pos = coll.gameObject.transform.position;
		var offset = 0.5 * (pos.y > 0 ? 1 : -1);
		pos.y = (pos.y * -1) + (float)offset;
		coll.gameObject.transform.position = pos;
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
