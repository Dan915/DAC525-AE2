using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayRandomScript : MonoBehaviour {
	GameObject gameManager;
	GameObject livesText;
	int next;
	GameObject livesPanel;
	GameObject transition;
	public GameObject confetti;
	public GameObject ghost;
	Animator anim;
	public GameObject character;

	void Start () 
	{
		gameManager = GameObject.Find("GameManager");
		anim = gameManager.GetComponentInChildren<Animator>();
		anim.SetTrigger("Start");
		
		foreach(Transform trans in GameObject.Find("GameManager").GetComponentsInChildren<Transform>(true))
		{
			if(trans.name == "Lives") livesPanel = trans.gameObject;
			else if (trans.name == "Lives text") livesText = trans.gameObject;
			else if (trans.name == "Wave transition") transition = trans.gameObject;
			else if (trans.name == "Ghost") ghost = trans.gameObject;
			else if (trans.name == "Character") character = trans.gameObject;
		}
		livesPanel.SetActive(true);
		livesText.SetActive(true);
		next = Random.Range(2,14);
	}
	void Update()
	{
		if (gameManager.GetComponent<GameManagerScript>().winner == true)
		{
			confetti.SetActive(true);
			ghost.SetActive(false);
		}
		else if (gameManager.GetComponent<GameManagerScript>().winner == false)
		{			
			confetti.SetActive(false);
			ghost.SetActive(true);
		}
	}


	public IEnumerator LoadGame()
	{	
		anim.SetTrigger("Finish");
		yield return new WaitForSeconds(0.5f);
		character.SetActive(false);
		gameManager.GetComponent<GameManagerScript>().playedGames +=1;
		yield return new WaitForSeconds(1);
		livesPanel.SetActive(false);
		livesText.SetActive(false);
		SceneManager.LoadScene(next);
		ghost.SetActive(false);
		gameManager.GetComponentInChildren<Animator>().SetTrigger("Start");
		gameManager.GetComponent<GameManagerScript>().loading = false; 
	}
	
}
