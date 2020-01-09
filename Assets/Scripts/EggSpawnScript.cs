using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EggSpawnScript : MonoBehaviour {
	float maxX = 6.5f;
	float minX = -6.5f;
	float maxY = 10;
	float minY = 5;
	float randY;
	float randX;
	public GameObject[] Egg;
	float randAmmount;
	public List<GameObject> eggsList = new List<GameObject>();
	bool spawn = false;
	public int dropped;
	int minEggs = 1, maxEggs = 3, incDifficulty;
	GameObject GameManager;
	public int collectedEggs = 0;
	bool winner;

	// Use this for initialization
	void Start () 
	{
		GameManager = GameObject.Find("GameManager");
		winner = GameManager.GetComponent<GameManagerScript>().winner;
		incDifficulty = GameManager.GetComponent<GameManagerScript>().difficulty;
		minEggs += incDifficulty;
		maxEggs += incDifficulty;
		randAmmount = Random.Range(minEggs, maxEggs);
		while(eggsList.Count != randAmmount)		
			eggsList.Add(Egg[Random.Range(0,Egg.Length)]);
	}
	void Update () 
	{

		if (eggsList.Count > 0 && GameObject.FindGameObjectsWithTag("Egg").Length <=1 && spawn == false)
		StartCoroutine(Instantiate());
		if (dropped == collectedEggs && dropped > 0)
		{
			Debug.Log("win screen");
			StartCoroutine(LoadScene());
		}
	}
	IEnumerator Instantiate()
	{
		spawn = true;
		randX = Random.Range(minX,maxX);
		randY = Random.Range(minY,maxY);
		yield return new WaitForSeconds(1.5f);
		Instantiate(eggsList[0],new Vector2(randX,randY) , Quaternion.identity);
		eggsList.RemoveAt(0);
		spawn = false;
		dropped++;
	}
		IEnumerator LoadScene()
	{
		GameManager.GetComponent<GameManagerScript>().anim.SetTrigger("Finish");
		winner = true;
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Load Scene");
	}
}
