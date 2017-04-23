using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileScript : MonoBehaviour {


	private GameObject[] targets;

	// Use this for initialization
	void Start () {
		targets = GameObject.FindGameObjectsWithTag("Enemy");
		var dist = Vector3.Distance(targets[0].transform.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
