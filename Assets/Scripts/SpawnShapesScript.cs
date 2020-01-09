using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnShapesScript : MonoBehaviour {

public GameObject[] possibleShapes;
public Transform[] spawnPoints;
Transform pos;
public int placedObj = 0;
int index;
private bool inProgress = false;
public GameObject bin, GameManager;
public List<GameObject> filesList = new List<GameObject>();
bool loadingScene = false;
GameManagerScript gameManager;
    

    void Start ()
    {
		GameManager = GameObject.Find("GameManager"); 
		gameManager = GameManager.GetComponent<GameManagerScript>();
		var randomAmount = Random.Range(2, 10);
		while(filesList.Count != randomAmount)		
			filesList.Add(possibleShapes[Random.Range(0,possibleShapes.Length)]);
    }
	
	void Update () 
	{
		BinScript binScript = bin.GetComponent<BinScript>();
		if (filesList.Count > 0 && GameObject.FindGameObjectsWithTag("Unplaced").Length == 0 && inProgress == false)
        {
			StartCoroutine(SpawnNewObject());			
        }
		else if (placedObj == binScript.destroyedObj && placedObj >= 1 && !loadingScene)
		{
			// Winner
			GameManager.GetComponent<GameManagerScript>().anim.SetTrigger("Finish");
			loadingScene = true;
			StartCoroutine(LoadScene());
		}
	}
	IEnumerator SpawnNewObject()
	{
		inProgress = true;
		index = Random.Range(0,spawnPoints.Length);
		pos = spawnPoints[index];
		yield return new WaitForSeconds(0.1f);
		GameObject newObject = Instantiate(filesList[0], pos.position, Quaternion.identity);
		filesList.RemoveAt(0);
		inProgress = false;
		placedObj++;
	}
			IEnumerator LoadScene()
	{
		gameManager.winner = true;
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Load Scene");
	}
}
