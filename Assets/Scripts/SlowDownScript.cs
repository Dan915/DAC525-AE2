using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlowDownScript : MonoBehaviour {

	float force;
    float speed = 350, incDifficulty;
	private Vector3 Ftouch;   
    private Vector3 Ltouch;   
    public int screenSize;
    private float dragDistance;  
	Rigidbody2D CarRB;
    GameObject GameManager;
    Animator anim;
    GameManagerScript gameManager;
   
    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        anim = GameManager.GetComponentInChildren<Animator>();
        gameManager = GameManager.GetComponent<GameManagerScript>();
		incDifficulty = GameManager.GetComponent<GameManagerScript>().difficulty * 50;
        dragDistance = Screen.height * screenSize / 100;
        speed += incDifficulty;
		CarRB = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine (Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        CarRB.bodyType = RigidbodyType2D.Dynamic;
        CarRB.AddForce(new Vector2(speed,0));
    }

    void Update()
    {
		if (CarRB.velocity.x < 0 && CarRB.bodyType == RigidbodyType2D.Dynamic )
		{
			Debug.Log("Stopped");
            CarRB.bodyType = RigidbodyType2D.Static;
            gameManager.winner = true;
            StartCoroutine(LoadScene());
           // stopped = true;
		}
		else
		    CarRB.AddForce(new Vector2(30,0));

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0); 
            if (touch.phase == TouchPhase.Began)
            {
                Ftouch = touch.position;
                Ltouch = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                Ltouch = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) 
            {
                Ltouch = touch.position; 
				force = Ltouch.x - Ftouch.x;

                if (Mathf.Abs(Ltouch.x - Ftouch.x) > dragDistance || Mathf.Abs(Ltouch.y - Ftouch.y) > dragDistance)
                {
                    if (Mathf.Abs(Ltouch.x - Ftouch.x) > Mathf.Abs(Ltouch.y - Ftouch.y))
                    {
                        if ((Ltouch.x < Ftouch.x)) 
                        {
							CarRB.AddForce(new Vector2(force /2,0));
                        }
                    }
                }
            }
        }
    }
    	IEnumerator LoadScene()
	{
        anim.SetTrigger("Finish");
		yield return new WaitForSeconds(0.5f);
		SceneManager.LoadScene("Load Scene");
	}
}
