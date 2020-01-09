using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObsticleScript : MonoBehaviour {
public	GameObject GameManager;
GameManagerScript gameManager;
bool loadingScene = false;

void Start()
{
	GameManager = GameObject.Find("GameManager");
	gameManager = GameManager.GetComponent<GameManagerScript>();
}
void OnTriggerEnter2D(Collider2D other)	
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Egg")
		{
			GameManager.GetComponent<GameManagerScript>().lives-=1 ;
			gameManager.winner = false;
			loadingScene = true;
			StartCoroutine(LoadScene());
		}
	}
void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			gameManager.winner = false;
			loadingScene = true;
			GameManager.GetComponent<GameManagerScript>().lives-=1 ;
			StartCoroutine(LoadScene());
		}
	}
	IEnumerator LoadScene()
	{
		GameManager.GetComponent<GameManagerScript>().anim.SetTrigger("Finish");
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Load Scene");
	}
	
}
