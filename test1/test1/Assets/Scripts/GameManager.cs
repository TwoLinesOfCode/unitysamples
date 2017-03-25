using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	// Use this for initialization
	public GameObject player;
	public Camera ourcrmera;
	Vector3 position;
	int speed = 10;
	bool isBuzz;
	int shake = 4;
	int delay = 10;
	int counter = 0;

	void Awake()
	{
		position = new Vector3(0, 0, 0);
		InvokeRepeating("NewShip", 2, 2);
		InvokeRepeating("SimulateBuzz", 5, 5);
	}

	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		counter++;
		if (counter > delay)
		{
			counter = 0;
			if (isBuzz)
			{
				//var cam = gameObject.GetComponent<Camera>();
				ourcrmera.transform.Rotate(0, 0, shake);
				shake *= -1;
			}
		}
	}


	void SimulateBuzz()
	{
		isBuzz = !isBuzz;
	}

	void NewShip()
	{
		var newSS = Instantiate(player, position, Quaternion.identity);
		var ss = newSS.GetComponent<spaceship>();
		ss.speed = speed;
		speed += 5;
		//newGO.transform.position = position;
		position.x += 0.1f;
		position.y += 0.1f;
		//Debug.Log(position);
	}
}
