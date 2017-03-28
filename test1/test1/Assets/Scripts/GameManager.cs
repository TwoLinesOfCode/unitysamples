using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	// Use this for initialization
	public Camera ourcrmera;

	private GameObject playerObject;
	//private float worldToPixel;
	private float pixelToWorld;

	void Awake()
	{
		InvokeRepeating("InitEnem", 1, 0.5f);
	}

	void Start()
	{
		//worldToPixel = ((Screen.height / 2.0f) / Camera.main.orthographicSize);
		pixelToWorld = Camera.main.orthographicSize / (Screen.height / 2.0f);

		playerObject = Instantiate(Resources.Load("prefab/spaceship", typeof(GameObject))) as GameObject;
		playerObject.transform.position = new Vector3(0, 0, 0);
	}

	// Update is called once per frame
	void Update()
	{

	}

	void InitEnem()
	{
		GameObject instance = Instantiate(Resources.Load("prefab/enem", typeof(GameObject))) as GameObject;
		var enemyScript = instance.GetComponent<EnemyScript>();
		enemyScript.EnemyDestroyed += EnemyScript_EnemyDestroyed;
		var xPosition = (UnityEngine.Random.value * (Camera.main.pixelWidth - 100) * pixelToWorld) - ((Camera.main.pixelWidth / 2) * pixelToWorld);
		var yPosition = (Camera.main.pixelHeight / 2) * pixelToWorld;
		instance.transform.position = new Vector2(xPosition, yPosition);
	}

	int enemyDestroyed = 0;

	private void EnemyScript_EnemyDestroyed(object sender, EventArgs e)
	{
		enemyDestroyed++;
		if (enemyDestroyed % 2 == 0)
		{
			InitPowerUp();
		}
	}

	void InitPowerUp()
	{
		GameObject instance = null;
		var rnd = UnityEngine.Random.value;
		if (rnd < 0.33f)
		{
			instance = Instantiate(Resources.Load("prefab/RedPowerup", typeof(GameObject))) as GameObject;
		}
		else if (rnd < 0.66)
		{
			instance = Instantiate(Resources.Load("prefab/YellowPowerup", typeof(GameObject))) as GameObject;
		}
		else
		{
			instance = Instantiate(Resources.Load("prefab/CyanPowerup", typeof(GameObject))) as GameObject;
		}
		
		var xPosition = (UnityEngine.Random.value * (Camera.main.pixelWidth - 100) * pixelToWorld) - ((Camera.main.pixelWidth / 2) * pixelToWorld);
		var yPosition = (Camera.main.pixelHeight / 2) * pixelToWorld;
		instance.transform.position = new Vector2(xPosition, yPosition);
	}
}
