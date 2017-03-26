using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript: MonoBehaviour {

	public float speed;
	public int health;
	Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
	}

	public void TakeDamage(int damage)
	{
		health = health - damage;
		if (health == 0) { Die(); }

	}

	private void Die()
	{
		Destroy(gameObject);
	}
}
