using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Interface;
using System;

public class PowerUpScript : MonoBehaviour, IPowerUp {

	public PowerUpTypes type
	{
		get
		{
			return PowerUpTypes.a;
		}

	}
}

public delegate void PowerUp(PowerUpTypes powerUp);
