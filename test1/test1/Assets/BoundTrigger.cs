using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundTrigger : MonoBehaviour
{

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "playerTag")
		{
			var pos = coll.gameObject.transform.position;
			var offset = 0.5 * (pos.y > 0 ? 1 : -1);
			pos.y = (pos.y * -1)+ (float)offset;
			coll.gameObject.transform.position = pos ;
		}

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
