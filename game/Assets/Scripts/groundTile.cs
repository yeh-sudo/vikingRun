using UnityEngine;

public class groundTile : MonoBehaviour{

    tileSpawner groundSpawner;

    // Start is called before the first frame update
    void Start(){
        groundSpawner = GameObject.FindObjectOfType<tileSpawner>();
    }

    private void OnTriggerExit(Collider other) {
        groundSpawner.spawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update(){
        
    }
}
