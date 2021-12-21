using UnityEngine;
using System;

public class tileSpawner : MonoBehaviour{

    [SerializeField] private GameObject groundTile;
    Vector3 nextSpawnerPoint;
    private System.Random crand = new System.Random();
    private int straight = 5;
    private int left = 0;
    private int right = 0;
    

    private int randint() {
        if (straight != 0) {
            straight--;
            int ishole = crand.Next(1, 9);
            if (ishole == 8) {
                return 4;
            }
            return 1;
        }
        if (right != 0) {
            right--;
            int ishole = crand.Next(1, 9);
            if (ishole == 8) {
                return 5;
            }
            return 3;
        }
        if (left != 0) {
            left--;
            int ishole = crand.Next(1, 9);
            if (ishole == 8) {
                return 6;
            }
            return 2;
        }
        int tmp = crand.Next(1, 15);
        if (tmp <= 10 && tmp >= 1) {
            straight = 5;
            return 1;
        }
        else if (tmp >= 11 && tmp <= 12) {
            left = 5;
            return 2;
        }
        else {
            right = 5;
            return 3;
        }
    }

    public void spawnTile() {
        int idx = randint();
        GameObject tmp = Instantiate(groundTile, nextSpawnerPoint, Quaternion.identity);
        nextSpawnerPoint = tmp.transform.GetChild(idx).transform.position;
        // return idx;
    }

    // Start is called before the first frame update
    void Start(){
        for (int i = 0; i < 40; i++) {
            spawnTile();
        }
    }
}
