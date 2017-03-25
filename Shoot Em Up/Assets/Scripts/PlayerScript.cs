using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript: MonoBehaviour {

	public float speed;
	public int health;
	public GameObject bullet;

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

		if (Input.GetKey(KeyCode.Mouse0))
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
		health = health - damage;
		if (health == 0) { Die(); }

	}

	private void Shoot()
	{
		Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
		
	}

	private void Die()
	{
		Destroy(gameObject);
	}
}
