using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float jumpForce;
	private float moveInput;
	private Rigidbody2D rb;
	public GameObject gameController;
	public bool isIt;
	public GameObject indicator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Player1_Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    void Update(){
    		if(Input.GetButtonDown("Player1_Jump")){
   				rb.velocity = Vector2.up * jumpForce;
    		}
    		if (isIt) {
    			indicator.SetActive(true);
    		} else {
    			indicator.SetActive(false);
    		}
    } 

    void OnCollisionEnter2D(Collision2D col) {
    	if (col.gameObject.tag=="Player") {
       		if (isIt) {
          		  gameController.GetComponent<gameController>().resetTimer();
       		} 
        	isIt = !isIt;
    	}
	}
}
