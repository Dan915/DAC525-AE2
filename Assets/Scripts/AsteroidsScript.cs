using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AsteroidsScript : MonoBehaviour {

	GameObject player;
	public float speed;
	int incDifficulty;
	public GameObject GameManager;
	GameManagerScript gameManager;
	void Start()
	{
		GameManager = GameObject.Find("GameManager");
		gameManager = GameManager.GetComponent<GameManagerScript>();
		incDifficulty = GameManager.GetComponent<GameManagerScript>().difficulty;
		speed += incDifficulty;
		player = GameObject.Find("Player");
		gameObject.transform.position = new Vector3(transform.position.x,transform.position.y,0);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			GameManager.GetComponent<GameManagerScript>().lives-=1 ;
			Debug.Log("Game Over");
			gameManager.winner = false;
			StartCoroutine(LoadScene());
		}
	}
		IEnumerator LoadScene()
	{
		GameManager.GetComponent<GameManagerScript>().anim.SetTrigger("Finish");
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Load Scene");
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2);
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	}
	void Update ()
	 {
		StartCoroutine(Wait());
	}
}
