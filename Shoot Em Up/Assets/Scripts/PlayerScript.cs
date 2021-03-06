﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts.Enum;

public class PlayerScript: MonoBehaviour {

	public float speed;
	public int health;
	GameObject bullet;
	public float bulletSpawnOffset;

	Rigidbody2D rb;
	int firingCounter = 0;
	int bulletFireRateDelay;

	void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		LoadBullet("SingleShotBullet");
	}

	void Update () {
		rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Shoot();
		}

		if (Input.GetKey(KeyCode.Space))
		{
			if (bulletFireRateDelay < firingCounter)
			{
				Shoot();
				firingCounter = 0;
			}
			firingCounter++;
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			firingCounter = 0;
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
		LoadBullet("TripleShotBullet");
		
	}

	void LoadBullet(string bulletName)
	{
		bullet = Resources.Load<GameObject>("Prefabs/"+bulletName);
		bulletFireRateDelay = bullet.GetComponent<BulletDataScript>().fireRateDelay;
	}

	private void Die()
	{
		Destroy(gameObject);
	}
}
