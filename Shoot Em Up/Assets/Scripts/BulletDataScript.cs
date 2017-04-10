using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Enum;

public class BulletDataScript : MonoBehaviour {

	public int damage;
	public float speed;
	public bool shootDown;
	public int fireRateDelay;
	public AudioClip firingSound;
	public event PowerUpScript.PowerUp Powered;

	public void OnPowerUp(PowerUpTypes type)
	{
		if (Powered != null)
		{
			Powered(type);
		}
	}

}