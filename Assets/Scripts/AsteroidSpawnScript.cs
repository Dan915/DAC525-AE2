using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsteroidSpawnScript : MonoBehaviour {
	public Transform[] spawnPoints;
	Transform pos;
	public GameObject[] Asteroids;
	float randAmmount;
	public List<GameObject> asteroidList = new List<GameObject>();
	bool spawn = false;
	int index;
	public float spawnDelay;

	[HideInInspector]

	// Use this for initialization
	void Start () 
	{
		
		randAmmount = Random.Range(4, 8);
		while(asteroidList.Count != randAmmount)		
			asteroidList.Add(Asteroids[Random.Range(0,Asteroids.Length)]);
	}
	void Update () 
	{
		if (asteroidList.Count > 0 && spawn == false)
		StartCoroutine(Instantiate());
	}
	IEnumerator Instantiate()
	{
		spawn = true;
		index = Random.Range(0,spawnPoints.Length);
		pos = spawnPoints[index];
		yield return new WaitForSeconds(spawnDelay);
		GameObject Myobject = Instantiate(asteroidList[0], pos.position, Quaternion.identity);
		asteroidList.RemoveAt(0);
		spawn = false;
	}
	// 	IEnumerator LoadScene()
	// {
	// 	yield return new WaitForSeconds(1);
	// 	SceneManager.LoadScene("Load Scene");
	// }
}

