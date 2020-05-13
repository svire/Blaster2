using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour {

    public float playerSpeed = 10f;
    public GameControl gameController;
    public GameObject bulletPrefab;
    public float reloadTime = 0.5f;//player can fire a bullet every half second
    public GameObject circle;
    private float elapsedTime = 0;

	void Start () {
		
	}
	
	 
	void Update () {

        elapsedTime += Time.deltaTime;///keep track of time for bullet firing
        //Move the player left and right

        float xMovement = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float xPosition = Mathf.Clamp(xMovement, -7f, 7f);//keep ship on screen
        transform.Translate(xPosition, 0f, 0f);


        float yMovement = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        float yPosition = Mathf.Clamp(-7f, yMovement, 7f);
        transform.Translate(0f, yPosition, 0f);

        //Spacebar fires. jUMP=SPACE
        if(Input.GetButtonDown("Jump")&&elapsedTime>reloadTime)
        {
            //instantiate bullet 1.2 units in front of the player and in he foregroun at z=-5
            Vector3 spawnPos = transform.position;
            //saberi dva vektora i ispred na 
                                   //(x,y,z)
             
            spawnPos += new Vector3(-0.2f, 1.2f, 0);

            Vector3 spawnPos2 = transform.position;
            spawnPos2 += new Vector3(0.2f, 1.2f, 0);            
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
            Instantiate(bulletPrefab, spawnPos2, Quaternion.identity);
            elapsedTime = 0f;//reset bullet firing timer..
            //kad upuca da ti koordiante na kojima se nalazi 
            //tipa{(0.8,0.4,0.0)
            print(transform.position);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Vector3 spawnPos = transform.position;

            spawnPos +=new  Vector3(2f, 2f,0);
            Instantiate(circle, spawnPos, Quaternion.identity);
        }
        Destroy(circle.gameObject);

		
	}
    //if a meteor hits a player
    void OnTriggerEnter2D(Collider2D other)
    {
        gameController.PlayerDied();//tamo ce pozvati onaj gam eover da iskoci
    }
}
