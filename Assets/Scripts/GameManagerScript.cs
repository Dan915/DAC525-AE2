using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {
	public int lives = 4;
	public Image live1;
	public Image live2;
	public Image live3;
	public Image live4;
	public Sprite Heart;
	public Sprite brokenHeart;
	public int lastScene;
	int currentScene;
	public int timeDecrease;
	public int difficulty;
	public int playedGames;
	public Animator anim;
	public bool winner;
	public GameObject character;
	Animator characterAnim;

	public AnimationClip[] winClips;
	public AnimationClip[] loseClips;

	public int arrayOffset = 2;

	public bool loading = false;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(gameObject);	
		live1.GetComponent<Image>();
		live2.GetComponent<Image>();
		live3.GetComponent<Image>();
		live4.GetComponent<Image>();
		if( GameObject.FindGameObjectsWithTag("GameController").Length >1)
		{
			Destroy(this.gameObject);
		}	
		characterAnim = character.GetComponent<Animator>();
		//StartCoroutine(LoadLevel());
	}


    // Update is called once per frame
    void Update () 
	{
		if (playedGames == 5)
		{
			timeDecrease++;
			difficulty++;
			playedGames = 0;
		}
		if (timeDecrease >= 5)
			timeDecrease = 5;
		if (difficulty >= 5)
			difficulty = 5;
		// THIS CODE IS REAL UGLY AND I WILL FIX IT IN FUTURE PATCH
		switch (lives)
		{
			case 4:
 				live1.sprite = Heart;
				live2.sprite = Heart;
				live3.sprite = Heart;
				live4.sprite = Heart;
					break;
			case 3:
				live1.sprite = Heart;
				live2.sprite = Heart;
				live3.sprite = Heart;
				live4.sprite = brokenHeart;
					break;
			case 2:
				live1.sprite = Heart;
				live2.sprite = Heart;
				live3.sprite = brokenHeart;
				live4.sprite = brokenHeart;
					break;
			case 1:
				live1.sprite = Heart;
				live2.sprite = brokenHeart;
				live3.sprite = brokenHeart;
				live4.sprite = brokenHeart;				
					break;
			case 0:
				live1.sprite = brokenHeart;
				live2.sprite = brokenHeart;
				live3.sprite = brokenHeart;
				live4.sprite = brokenHeart;	
				StartCoroutine(LoadLevel());
					break;
			default:
			break;
		}
		
		currentScene = SceneManager.GetActiveScene().buildIndex;
		if (currentScene > 1)
		{
		lastScene = SceneManager.GetActiveScene().buildIndex;
		character.SetActive(false);
		}
		else if (currentScene == 1 && !loading) 
		{
			loading = true;
			Invoke("PlayAnim", 1.5f);
		}
		
	}
	void PlayAnim()
	{
		
		character.SetActive(true);
		AnimationClip animClip = null;
		//LEVEL_X_WIN LEVEL_X_LOOSE
		foreach(var item in winClips)
			Debug.Log(item.name);
		if(winner)
			animClip = winClips[lastScene - arrayOffset];
		else
			animClip = loseClips[lastScene - arrayOffset];
			
		character.GetComponent<Animator>().Play(animClip.name);
		Invoke("EndAnim", animClip.length - 0.5f);
	}

	void EndAnim()
	{
		//character.SetActive(false);
		if (lives > 0)
			StartCoroutine(Camera.main.GetComponent<PlayRandomScript>().LoadGame());
	}
	IEnumerator LoadLevel()
	{
		if (lives == 0)
		{
			yield return new WaitForSeconds(2);
			anim.SetTrigger("Finish");
			yield return new WaitForSeconds(1);
			character.SetActive(false);
			SceneManager.LoadScene("Main Menu");
			Destroy(this.gameObject);
		}
		// else if (lives > 0)
		// {
		// 	Debug.Log("lives");
		// 	yield return new WaitForSeconds(0.1f);
		// 	SceneManager.LoadScene("Load Scene");
		// }
	}
	public void MainMenu()
	{
		SceneManager.LoadScene("Main Menu");
	}
}
