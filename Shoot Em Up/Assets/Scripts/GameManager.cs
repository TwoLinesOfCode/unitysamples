using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public float spawnRate;
	public float spawnWidthOffset, spawnHeightOffset;
	List<object> enemy;
	float spawnWidth, spawnHeight;
	
	float t = 0f;
	float duration = 2f;


	// Use this for initialization
	void Start () {
		enemy = new List<object>();
		enemy.Add(Resources.Load("Prefabs/Enemy"));
		enemy.Add(Resources.Load("Prefabs/shootingEnemy"));
		
		spawnHeight = Camera.main.orthographicSize  + spawnHeightOffset;
		spawnWidth = (Camera.main.orthographicSize * Camera.main.aspect) - spawnWidthOffset;

		InvokeRepeating("SpawnEnemy", 7, spawnRate);

		InvokeRepeating("ChangeBGColor", 35, 0.1f);

		AudioSource music = gameObject.AddComponent<AudioSource>();
		music.clip = Resources.Load<AudioClip>("Sounds/Chipzel - Otis");
		music.volume = 0.15f;
		music.Play();
	}
	
	void SpawnEnemy()
	{
		var temp = Random.Range(0, enemy.Count);
		Instantiate((GameObject)enemy[temp], new Vector3(Random.Range(spawnWidth * -1, spawnWidth), spawnHeight), Quaternion.identity);
	}

	void ChangeBGColor()
	{
		if (t > duration)
		{
			CancelInvoke("ChangeBGColor");
		}

		Color lerpedColor = Camera.main.backgroundColor;
		lerpedColor = Color.Lerp(Camera.main.backgroundColor, new Color(0.35f, 0.2f, 0.2f), t);
		t += Time.deltaTime / duration;
		Camera.main.backgroundColor = lerpedColor; 
	}
}
