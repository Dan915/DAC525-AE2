using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EggScript : MonoBehaviour {

	public GameObject GameManager;
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
			Destroy(gameObject);
			Camera.main.gameObject.GetComponent<EggSpawnScript>().collectedEggs += 1;
		}
		else
		{
			gameManager.winner = false;
			Debug.Log("Game Over");
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
