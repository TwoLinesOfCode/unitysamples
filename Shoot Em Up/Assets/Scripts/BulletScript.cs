using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public int damage;
	public float speed;
	public bool shootDown;
	public int fireRateDelay;
	int dir = 1;
	Rigidbody2D rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		if (shootDown) { dir = -1; }
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(0, speed*dir);
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		var collidedWith = collision.gameObject;
		switch (collidedWith.tag)
		{
			case "Enemy":
				collidedWith.GetComponent<EnemyScript>().TakeDamage(damage);
				break;
			case "Player":
				collidedWith.GetComponent<PlayerScript>().TakeDamage(damage);
				break;
		}
	}
}
