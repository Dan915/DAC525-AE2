using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

	public int time;
	public int decreaseTime;  
	public GameObject timerBar;
	[Range(0, 10)] public float currentTime;
	public GameObject GameManager, WinScreen;
	public bool isFinishLine;
	bool loose = false;
	Animator anim;
	GameManagerScript gameManager;
	bool loadingScene = false;

	private float startTime;

	// Use this for initialization
	void Start () 
	{
		GameManager = GameObject.Find("GameManager");
		anim = GameManager.GetComponentInChildren<Animator>();
		gameManager = GameManager.GetComponent<GameManagerScript>();
		decreaseTime = GameObject.Find("GameManager").GetComponent<GameManagerScript>().timeDecrease;
		time -= decreaseTime;
		currentTime = time;
	} 		
	// Update is called once per frame
	void Update () 
	{
		if(currentTime <= 0.0f) currentTime = 0;
		else currentTime -= Time.deltaTime;

		timerBar.GetComponent<Image>().fillAmount = currentTime / time;
		// 0.5 / 50%
		
		if(currentTime == 0 && !loadingScene)
		{
			loadingScene = true;
			gameManager.winner = isFinishLine;
			StartCoroutine(LoadScene());
		}
	}
	IEnumerator LoadScene()
	{
		if (!isFinishLine)
			GameManager.GetComponent<GameManagerScript>().lives-=1 ;
		anim.SetTrigger("Finish");
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Load Scene");
		
	}
	
}
