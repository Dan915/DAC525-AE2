using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private GameObject Player;
    private Vector2 StartVec;
    public float Max_X;
    
	void Start () {
        StartVec = transform.position;
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update () {
        transform.position = new Vector3(
            Player.transform.position.x,
            Player.transform.position.y,
            -10);
	}

    private void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, StartVec.x, Max_X),
            Mathf.Clamp(transform.position.y, StartVec.y, 99),
            -10);
    }
}
