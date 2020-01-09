using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLineScript : MonoBehaviour {
public GameObject winScreen;
GameObject GameManager;
GameManagerScript gameManager;
void Start()
{
	GameManager = GameObject.Find("GameManager");
	gameManager = GameManager.GetComponent<GameManagerScript>();
}
void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			StartCoroutine(LoadScene());
		}
	}
void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "obsticle")
		Debug.Log("ssss");
		//StartCoroutine(LoadScene());
	}

IEnumerator LoadScene()
	{
		GameManager.GetComponent<GameManagerScript>().anim.SetTrigger("Finish");
		gameManager.winner = true;
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Load Scene");
	}

}
