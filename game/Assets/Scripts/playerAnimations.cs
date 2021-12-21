using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimations : MonoBehaviour{

    private Animator anim;
    private CharacterController myCharacterController;

    // Start is called before the first frame update
    void Start(){
        anim = GetComponent<Animator>();
        myCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update(){
        
    }
}
