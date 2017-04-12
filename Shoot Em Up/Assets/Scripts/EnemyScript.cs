using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public float ySpeed;
	public float fireRate;
	public float health;
	public bool canShoot;

	object bullet;
	Rigidbody2D rb;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start () {
		if (canShoot)
		{
			bullet = Resources.Load("Prefabs/SingleShotBullet");
			InvokeRepeating("Shoot", 1, fireRate);
		}
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(0, ySpeed*-1);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		TakeDamage(1);
		Debug.Log("enemy hit " + collision.gameObject.name);
		if (collision.gameObject.tag.Equals("Player"))
		{
			collision.gameObject.GetComponent<PlayerScript>().TakeDamage(1);
		}
	}

	public void TakeDamage(int damage)
	{
		health = health - damage;
		if(health == 0) { Die(); }

	}

	private void Shoot()
	{
		var bulletSpawnPos = gameObject.transform.position;
		bulletSpawnPos.y -= 1.5f;
		Instantiate((GameObject)bullet, bulletSpawnPos, Quaternion.identity).GetComponent<BulletDataScript>().shootDown = true;

	}

	private void Die()
	{
		GetComponent<AudioSource>().Play();
		GetComponent<Renderer>().enabled = false;
		Destroy(gameObject, 0.5f	);
	}
}
