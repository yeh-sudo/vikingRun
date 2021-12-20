using UnityEngine;
using System;

public class groundTile : MonoBehaviour{

    tileSpawner groundSpawner;
    public GameObject obstacle;
    public GameObject coinPrefab;
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
        spawnCoins();
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

    void spawnCoins() {
        int coinsToSpawn = 1;
        for (int i = 0; i < coinsToSpawn; i++) {
            GameObject tmp = Instantiate(coinPrefab, transform);
            tmp.transform.position = getRndPoint(GetComponent<Collider>());
        }
    }

    Vector3 getRndPoint(Collider collider) {
        Vector3 point = new Vector3(
            UnityEngine.Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            UnityEngine.Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            UnityEngine.Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if (point != collider.ClosestPoint(point)) {
            point = getRndPoint(collider);
        }

        point.y = 1;
        return point;
    }
}
