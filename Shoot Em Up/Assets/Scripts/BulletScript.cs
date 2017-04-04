using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Interface;

public class BulletScript : MonoBehaviour {

	int dir = 1;
	Rigidbody2D rb;
	BulletDataScript props;

	private void Awake()
	{
		props = GetComponent<BulletDataScript>();
		rb = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		if (props.shootDown) { dir = -1; }
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = transform.up * props.speed * dir;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		var collidedWith = collision.gameObject;
		switch (collidedWith.tag)
		{
			case "Enemy":
				collidedWith.GetComponent<EnemyScript>().TakeDamage(props.damage);
				break;
			case "Player":
				collidedWith.GetComponent<PlayerScript>().TakeDamage(props.damage);
				break;
			case "PowerUp":
				props.OnPowerUp(collidedWith.GetComponent<PowerUpScript>().type);
				break;
		}
	}
}
