using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObsticlesSpawnScript : MonoBehaviour {
	public Transform[] spawnPoints;
	Transform pos;
	public GameObject[] obsticles;
	int randAmmount;
	public int minObsticles;
	public int maxObsticles;
	public List<GameObject> obsticlesList = new List<GameObject>();
	bool spawn = false;
	int index;
	public float spawnDelay;
	public int incDifficulty;
	 GameObject GameManager;
	 bool ready = false;

	void Start () 
	{
		GameManager = GameObject.Find("GameManager");
		incDifficulty = GameManager.GetComponent<GameManagerScript>().difficulty;
		minObsticles += incDifficulty;
		maxObsticles += incDifficulty;
		randAmmount = Random.Range(minObsticles, maxObsticles);
		while(obsticlesList.Count != randAmmount)		
			obsticlesList.Add(obsticles[Random.Range(0,obsticles.Length)]);
		StartCoroutine(wait());
	}
	void Update () 
	{
		if (obsticlesList.Count > 0 && spawn == false && ready)
		StartCoroutine(Instantiate());
	}
	IEnumerator wait()
	{
		yield return new WaitForSeconds(1.5f);
		ready = true;
	}
	IEnumerator Instantiate()
	{
		spawn = true;
		index = Random.Range(0,spawnPoints.Length);
		pos = spawnPoints[index];
		yield return new WaitForSeconds(spawnDelay);
		GameObject Myobject = Instantiate(obsticlesList[0], pos.position, Quaternion.identity);
		Myobject.transform.Rotate(0,180,0);
		obsticlesList.RemoveAt(0);
		spawn = false;
	}
}

