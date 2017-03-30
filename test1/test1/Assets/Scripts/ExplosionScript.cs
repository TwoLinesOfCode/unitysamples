using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {

	// Use this for initialization
	int counter;
	private AudioSource source;

	void Awake()
	{
		source = GetComponent<AudioSource>();
	}

	void Start () {
		counter = 0;
		AudioClip clip = Resources.Load("Sounds/shoot_2", typeof(AudioClip)) as AudioClip;
		source.PlayOneShot(clip, 0.8f);
	}
	
	// Update is called once per frame
	void Update () {
		counter++;
		if (counter > 100)
		{
			DestroyObject(gameObject);
		}
	}
}
