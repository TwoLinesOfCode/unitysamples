using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class spaceship : MonoBehaviour
{
	bool isShooting = false;
	GameObject bullet;
	int shootRate = 20;
	private AudioSource source;
	private BulletTypes bulletType;

	public float speed;
	// Use this for initialization
	void Awake()
	{
		source = GetComponent<AudioSource>();
		bulletType = BulletTypes.Bulky;
	}

	void Start()
	{
		InvokeRepeating("TryShoot", 0, 1 / 60f);
	}

	// Update is called once per frame
	void Update()
	{

		if (IsAllowToMove())
		{
			var xTrans = speed * Input.GetAxis("Horizontal");
			var yTrans = speed * Input.GetAxis("Vertical");
			this.transform.Translate(new Vector3(xTrans, yTrans, 0));
			//rb.Move(new Vector3(xTrans, yTrans, 0));
			//rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
			//rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));
			//HandleRotation();
		}
		Shoot();
	}

	private bool IsAllowToMove()
	{
		if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0) return false;

		var camera = Camera.main;
		Vector3 bottomLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, camera.nearClipPlane));

		Vector3 topRight = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, camera.nearClipPlane));

		if (Input.GetAxis("Horizontal") > 0 && this.transform.position.x > topRight.x) return false;
		if (Input.GetAxis("Horizontal") < 0 && this.transform.position.x < bottomLeft.x) return false;
		if (Input.GetAxis("Vertical") > 0 && this.transform.position.y > topRight.y) return false;
		if (Input.GetAxis("Vertical") < 0 && this.transform.position.y < bottomLeft.y) return false;

		return true;
	}

	private void Shoot()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			shootCounter = 0;
		}
		if (Input.GetKey(KeyCode.Space))
		{
			isShooting = true;
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			isShooting = false;
		}
	}

	int shootCounter = 0;
	private void TryShoot()
	{
		if (isShooting)
		{
			if (shootCounter % shootRate == 0)
			{
				CreateNewBulletAndShoot();
				shootCounter = 0;
			}
		}
		shootCounter++;
	}

	private void CreateNewBulletAndShoot()
	{
		AudioClip clip = null;

		switch (bulletType)
		{
			case BulletTypes.Laser:
				bullet = Instantiate(Resources.Load("prefab/bullet", typeof(GameObject))) as GameObject;
				clip = Resources.Load("Sounds/shoot_1", typeof(AudioClip)) as AudioClip;
				break;
			case BulletTypes.Bulky:
				bullet = Instantiate(Resources.Load("prefab/NewBullet", typeof(GameObject))) as GameObject;
				clip = Resources.Load("Sounds/shoot_4", typeof(AudioClip)) as AudioClip;
				break;
			case BulletTypes.Red:
				bullet = Instantiate(Resources.Load("prefab/RedBullet", typeof(GameObject))) as GameObject;
				clip = Resources.Load("Sounds/shoot_3", typeof(AudioClip)) as AudioClip;
				break;
		}

		bullet.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.8f, 0);
		source.PlayOneShot(clip, 0.6f);

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Powerup")
		{
			switch (coll.gameObject.name)
			{
				case "RedPowerup(Clone)":
					this.bulletType = BulletTypes.Red;
					break;
				case "CyanPowerup(Clone)":
					this.bulletType = BulletTypes.Laser;
					break;
				case "YellowPowerup(Clone)":
					this.bulletType = BulletTypes.Bulky;
					break;
			}
			Destroy(coll.gameObject);
		}
	}
}
