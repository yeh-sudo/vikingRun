using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DieMenu : MonoBehaviour{
    
    public void gotoMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    public void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
