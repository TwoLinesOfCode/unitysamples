using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int spawnRate;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		
		InvokeRepeating("SpawnEnemy", 2, spawnRate);
	}
	
	void SpawnEnemy()
	{
		//Instantiate(enemy, new Vector3(Random.Range()
	}
}
