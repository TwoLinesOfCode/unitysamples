using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public int spawnRate;
	public float spawnWidthOffset, spawnHeightOffset;
	object enemy;
	float spawnWidth, spawnHeight;

	// Use this for initialization
	void Start () {
		enemy = Resources.Load("Prefabs/Enemy");
		var _camera = FindObjectOfType<Camera>();
		spawnHeight = _camera.orthographicSize  + spawnHeightOffset;
		spawnWidth = (_camera.orthographicSize * _camera.aspect) - spawnWidthOffset;
		InvokeRepeating("SpawnEnemy", 2, spawnRate);
	}
	
	void SpawnEnemy()
	{
		Instantiate((GameObject)enemy, new Vector3(Random.Range(spawnWidth * -1, spawnWidth), spawnHeight), Quaternion.identity);
	}
}
