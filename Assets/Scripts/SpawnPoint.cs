using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
	public GameObject item;
	public Vector2[] spawnPoint;

	void Start () 
	{			
		Instantiate(item, spawnPoint[Random.Range(0,spawnPoint.Length)],Quaternion.identity);
	}
}


