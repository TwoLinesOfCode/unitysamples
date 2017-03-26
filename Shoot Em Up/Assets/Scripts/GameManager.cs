using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int spawnRate;
	public float spawnWidthOffset, spawnHeightOffset;
	List<object> enemy;
	float spawnWidth, spawnHeight;

	// Use this for initialization
	void Start () {
		enemy = new List<object>();
		enemy.Add(Resources.Load("Prefabs/Enemy"));
		enemy.Add(Resources.Load("Prefabs/shootingEnemy"));
		var _camera = FindObjectOfType<Camera>();
		spawnHeight = _camera.orthographicSize  + spawnHeightOffset;
		spawnWidth = (_camera.orthographicSize * _camera.aspect) - spawnWidthOffset;
		InvokeRepeating("SpawnEnemy", 2, spawnRate);
	}
	
	void SpawnEnemy()
	{
		var temp = Random.Range(0, enemy.Count);
		Instantiate((GameObject)enemy[temp], new Vector3(Random.Range(spawnWidth * -1, spawnWidth), spawnHeight), Quaternion.identity);
	}
}
