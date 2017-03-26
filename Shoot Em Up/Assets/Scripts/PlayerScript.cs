using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript: MonoBehaviour {

	public float speed;
	public int health;
	public GameObject bullet;
	public float bulletSpawnOffset;

	Rigidbody2D rb;
	int firingCounter = 0;

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

		if (Input.GetKey(KeyCode.Space))
		{
			if(bullet.GetComponent<BulletScript>().fireRateDelay < firingCounter)
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
		Instantiate(bullet, bulletSpawnPos, Quaternion.identity);
		
	}

	private void Die()
	{
		Destroy(gameObject);
	}
}
