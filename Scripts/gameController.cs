using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
	private float timeLeft = 15f;
	public GameObject player1;
	public GameObject player2;
	public Text score_text;
	public Text score_text2; 
	public int score1;
	public int score2;
	public Text alert;
	public Text timer;
	public Text winner;

    void Start(){
    	winner.enabled = false;
    	score1 = 0;
    	score2 = 0;
    	int num = Random.Range(1, 2);

    	if (num == 1){
    		player1.GetComponent<PlayerController>().isIt = true;
    		player2.GetComponent<PlayerController2>().isIt = false;
    	}
    	else{
    		player1.GetComponent<PlayerController>().isIt = false;
    		player2.GetComponent<PlayerController2>().isIt = true;
    	}
    }

    void Update(){
    	timeLeft -= Time.deltaTime;
    	timer.text = timeLeft.ToString("f2");

    	if(timeLeft <= 0){
    		if(player1.GetComponent<PlayerController>().isIt){
    			score2++;
    			player2.GetComponent<PlayerController2>().isIt = true;
    			player1.GetComponent<PlayerController>().isIt = false;
    		}
    		else{
    			score1++;
    			player2.GetComponent<PlayerController2>().isIt = false;
    			player1.GetComponent<PlayerController>().isIt = true;


    		}
    		timeLeft = 15f;

    	}
    	if(score1 == 2 && score2 == 0){
    		winner.enabled = true;
    		winner.text = "PLAYER 1 WINS!";
    		timer.enabled = false;
    	}
    	if(score2 == 2 && score1 == 0){
    		winner.enabled = true;
    		winner.text = "PLAYER 2 WINS!";
    		timer.enabled = false;
    	}
    	if(score1 + score2 >= 3){
    		winner.enabled = true;
    		if(score1 > score2){
    			winner.text = "PLAYER 1 WINS!";
    			timer.enabled = false;
    		}
    		else{
    			winner.text = "PLAYER 2 WINS!";
    			timer.enabled = false;
    		}

    	}

    	score_text.text = score1.ToString();
    	score_text2.text = score2.ToString();

    	if(player1.GetComponent<PlayerController>().isIt){
    		alert.text = "Player 1 (Black) is IT";
    	}
    	else{
    		alert.text = "Player 2 (Gray) is IT";
    	}
    }

    public void resetTimer(){
    	timeLeft = 15f;
    }
}
