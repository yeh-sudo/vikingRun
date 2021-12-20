using UnityEngine;
using System;

public class groundTile : MonoBehaviour{

    tileSpawner groundSpawner;
    public GameObject obstacle;
    private System.Random crand = new System.Random();

    private bool hasObs() {
        int tmp = crand.Next(1, 16);
        if (tmp == 15) {
            return true;
        }
        else {
            return false;
        }
    }

    // Start is called before the first frame update
    void Start(){
        groundSpawner = GameObject.FindObjectOfType<tileSpawner>();
        spawnObs();
    }

    private void OnTriggerExit(Collider other) {
        groundSpawner.spawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update(){
        
    }

    void spawnObs() {
        if (!hasObs()) {
            return;
        }
        int obstacleIdx = UnityEngine.Random.Range(7, 10);
        Transform spawnPoint = transform.GetChild(obstacleIdx).transform;
        Instantiate(obstacle, spawnPoint.position, Quaternion.identity, transform);
    }
}
