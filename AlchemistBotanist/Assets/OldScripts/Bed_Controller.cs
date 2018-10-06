using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed_Controller : MonoBehaviour {

    public Game_Manager gameManager;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ActivateActor()
    {
        gameManager.InitDay();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision enter");
        //other.transform.position = Vector3.zero;
        //gameManager.InitDay();

    }
}
