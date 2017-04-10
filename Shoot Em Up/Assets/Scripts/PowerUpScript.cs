using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Enum;
using System;

public class PowerUpScript : MonoBehaviour {

	public PowerUpTypes type
	{
		get
		{
			return PowerUpTypes.a;
		}

	}
	public delegate void PowerUpDelegate(PowerUpTypes type);
}