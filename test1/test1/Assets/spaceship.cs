using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceship : MonoBehaviour
{

	Rigidbody2D rb;

	public float speed;
	// Use this for initialization
	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		//InvokeRepeating("MoveLeft", 0, 2);
	}

	// Update is called once per frame
	void Update()
	{
		rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
		rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
		HandleRotation();
	}

	private void HandleRotation()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.Rotate(0, 5, 0);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.Rotate(0, -5, 0);
		}
		else
		{
			var q = this.transform.rotation;
			q.y = 0;
			this.transform.rotation = q;
		}
	}

	void MoveLeft()
	{
		rb.AddForce(new Vector2(-speed, 0));
	}


}
