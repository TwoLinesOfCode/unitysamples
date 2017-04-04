using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Interface;
using System;

public class PlayerScript: MonoBehaviour {

	public float speed;
	public int health;
	GameObject bullet;
	public float bulletSpawnOffset;

	Rigidbody2D rb;
	int firingCounter = 0;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		bullet = Resources.Load<GameObject>("Prefabs/Bullet");
	}

	// Update is called once per frame
	void Update () {
		rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));

		if (Input.GetKey(KeyCode.Space))
		{
			if (bullet.GetComponent<BulletDataScript>().fireRateDelay < firingCounter)
			{
				Shoot();
				firingCounter = 0;
			}
			firingCounter++;
		}
	}

	public void TakeDamage(int damage)
	{
		Debug.Log("i got hit!");
		health = health - damage;
		if (health == 0) { Die(); }

	}

	private void Shoot()

	{
		var bulletSpawnPos = gameObject.transform.position;
		bulletSpawnPos.y += bulletSpawnOffset;
		var x = Instantiate(bullet, bulletSpawnPos, Quaternion.identity);
		var script = x.GetComponent<BulletDataScript>();
		script.Powered += Script_OnPowerUp;
		
	}

	private void Script_OnPowerUp(PowerUpTypes POType)
	{
		Debug.Log("power up! of type " + Enum.GetName(typeof(PowerUpTypes), POType));
		bullet = Resources.Load<GameObject>("Prefabs/TripleShotBullet");
	}

	private void Die()
	{
		Destroy(gameObject);
	}
}
