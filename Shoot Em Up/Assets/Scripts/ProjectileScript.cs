using Assets.Scripts.Enum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	BulletDataScript props;
	Rigidbody2D rb;
	int dir = 1;

	private void Awake()
	{
		props = GetComponentInParent<BulletDataScript>();
		rb = GetComponent<Rigidbody2D>();
	}
	// Use this for initialization
	void Start () {
		if (props.shootDown) { dir = -1; }
	}

	void Update()
	{
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
