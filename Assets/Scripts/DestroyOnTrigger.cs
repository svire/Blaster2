using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
