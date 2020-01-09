using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatternScript : MonoBehaviour {
	public GameObject bongo1;
	public GameObject bongo2;
	public int maxCombinations = 5;
	public string pattern;
	public string input;
	bool win = false;
	GameObject GameManager;
	int randomN;
 	public List<int> patternList = new List<int>();
	int counter, incDifficulty;
	public GameObject timer;
	GameManagerScript gameManager;
	bool loadingScene = false;
	// Use this for initialization
	void Start () 
	{		
		GameManager = GameObject.Find("GameManager");
		gameManager = GameManager.GetComponent<GameManagerScript>();
		incDifficulty = GameManager.GetComponent<GameManagerScript>().difficulty;
		maxCombinations += incDifficulty;
		for (int i = 0; i < maxCombinations; i++)
		{
			randomN = Random.Range(0,2);
			patternList.Add(randomN);
		}
		StartCoroutine(Wait());

		Debug.Log(string.Join(", ", patternList.Select(x=>x.ToString()).ToArray()));
	}
	IEnumerator Wait()
	{
		yield return new WaitForSeconds(2.5f);

		foreach (var item in patternList)
		{
			counter++;;
			Debug.Log(item);
			switch (item)
			{
				case 0:
					bongo1.GetComponent<SpriteRenderer>().color = Color.white;
					yield return new WaitForSeconds(0.3f);
					bongo1.GetComponent<SpriteRenderer>().color = Color.black;
					yield return new WaitForSeconds(0.3f);
					bongo1.GetComponent<SpriteRenderer>().color = Color.white;					
				break;
				case 1:

					bongo2.GetComponent<SpriteRenderer>().color = Color.white;
					yield return new WaitForSeconds(0.3f);
					bongo2.GetComponent<SpriteRenderer>().color = Color.black;
					yield return new WaitForSeconds(0.3f);
					bongo2.GetComponent<SpriteRenderer>().color = Color.white;

				break;
				default:
				break;
			}
		}
	}
	IEnumerator PlayBongo()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
			if(hit.collider != null && hit.collider.gameObject.name == "Bongo 1")	
			{
				Debug.Log ("Target Name: " + hit.collider.gameObject.name);
				input += 0;
				bongo1.GetComponent<SpriteRenderer>().color = Color.red;
				yield return new WaitForSeconds(0.15f);
				bongo1.GetComponent<SpriteRenderer>().color = Color.white;

			}
			else if (hit.collider != null && hit.collider.gameObject.name == "Bongo 2")
			{
				Debug.Log ("Target Name: " + hit.collider.gameObject.name);
				input += 1;
				bongo2.GetComponent<SpriteRenderer>().color = Color.red;
				yield return new WaitForSeconds(0.15f);
				bongo2.GetComponent<SpriteRenderer>().color = Color.white;

	
			}
	}

		void Update () 
	{
		if (counter == maxCombinations)
		StartCoroutine(Timer());
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)	
		{
			StartCoroutine(PlayBongo());	
			if(input == string.Join("", patternList.Select(x=>x.ToString()).ToArray()) && !loadingScene)
			{
				loadingScene = true;
				win = true;
				StartCoroutine(LoadScene());
			}
			else if (input.Length == maxCombinations && input != string.Join("", patternList.Select(x=>x.ToString()).ToArray()) || input.Length > maxCombinations && !loadingScene)
			{
				loadingScene = true;
				StartCoroutine(LoadScene());
			}
		}
	}
	IEnumerator Timer()
	{
		yield return new WaitForSeconds(1);
		timer.SetActive(true);
	}
	IEnumerator LoadScene()
	{
		GameManager.GetComponent<GameManagerScript>().anim.SetTrigger("Finish");
		yield return new WaitForSeconds(0.5f);
		if (win == true)
		{
			gameManager.winner = true;
			SceneManager.LoadScene("Load Scene");
		}
		else
		{
			GameManager.GetComponent<GameManagerScript>().lives-=1 ;
			gameManager.winner = false;
			SceneManager.LoadScene("Load Scene");
		}
	}
}
