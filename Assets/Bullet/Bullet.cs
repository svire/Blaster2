using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 10f;
    private GameControl gameController;//Note this is private this time

	void Start () {
        //because the bullet doesnt exist until the game is running 
        //we must find the game controller a different way
        gameController = GameObject.FindObjectOfType<GameControl>();

	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, speed * Time.deltaTime, 0f);//Move up
	}
    //this scirpt need to account for collisiton and the player scoring
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(other.gameObject);//destroy the meteor
        gameController.AddScore();//incrementt hte score
        Destroy(gameObject);//destory bullet too
    }
}
