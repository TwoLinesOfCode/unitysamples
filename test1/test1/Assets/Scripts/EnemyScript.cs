using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

	// Use this for initialization

	public int HP = 100;
	public event EventHandler EnemyDestroyed;

	void Awake()
	{
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		switch (coll.gameObject.tag)
		{
			case "bullet":
				ApplyDamage(coll.gameObject, GetBulletDamage(coll));
				break;
		}
	}

	private int GetBulletDamage(Collider2D coll)
	{
		switch (coll.name)
		{
			case "bullet(Clone)":
				return coll.gameObject.GetComponent<LaserBulletScript>().Damage;
			case "NewBullet(Clone)":
				return coll.gameObject.GetComponent<BulkyBulletScript>().Damage;
			case "RedBullet(Clone)":
				return coll.gameObject.GetComponent<RedBulletScript>().Damage;
			default:
				return 0;
		}
	}

	private void ApplyDamage(GameObject bulletObject, int damage)
	{
		HP  = HP - damage;
		if (HP <= 0)
		{
			var explosion = Instantiate(Resources.Load("prefab/explosion", typeof(GameObject))) as GameObject;
			explosion.transform.position = this.transform.position;
			Destroy(gameObject);
			if (EnemyDestroyed != null)
			{
				EnemyDestroyed(this, null);
			}
		}
		Destroy(bulletObject);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
