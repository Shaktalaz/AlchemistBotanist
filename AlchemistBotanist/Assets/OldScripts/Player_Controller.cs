using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {

    public float speed = 1.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Game_Manager gameManager;
    public GameObject playerMesh;

    private Quaternion rot;
    private Vector3 moveDirection = Vector3.zero;
    CharacterController controller;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<Game_Manager>();
	}
	
	// Update is called once per frame
	void Update () {
        controller = GetComponent<CharacterController>();
        if (!gameManager.doingSetup) {
            if (controller.isGrounded)
            {
                moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

                if (moveDirection != Vector3.zero)
                {
                    rot = Quaternion.LookRotation(moveDirection);
                }


                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
                if (Input.GetButton("Jump"))
                    moveDirection.y = jumpSpeed;
            }
            moveDirection.y -= gravity * Time.deltaTime;
            controller.Move(moveDirection * Time.deltaTime);
            playerMesh.transform.rotation = rot;
        }
        
    }
}
