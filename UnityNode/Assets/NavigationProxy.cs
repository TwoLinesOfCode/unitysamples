using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationProxy : MonoBehaviour
{
	public GameObject player;

	public void MovePlayer(Vector3 destination)
	{
		player.GetComponent<CubeMovement>().MoveTo(destination);
	}
}
