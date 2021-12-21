using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour{

    public float turnSpeed = -90f;

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.GetComponent<Obstacle>() != null) {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.name != "Ch24_nonPBR") {
            return;
        }


        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
