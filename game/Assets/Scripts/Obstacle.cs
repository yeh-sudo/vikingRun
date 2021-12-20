using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour{

    playerMovement PlayerMovement;

    // Start is called before the first frame update
    void Start(){
        PlayerMovement = GameObject.FindObjectOfType<playerMovement>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Ch24_nonPBR@Running Crawl") {
            PlayerMovement.die();
        }
    }

    // Update is called once per frame
    void Update(){
        
    }
}
