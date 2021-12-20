using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    [SerializeField] private float speed = 7.0f;
    private bool turnLeft, turnRight, jump;
    private CharacterController myCharacterController;
    private float jumpSpeed = 7.0f;
    private float ySpeed = -1.0f;
    private Vector3 upwardVec;
    private Vector3 moveDir;


    // Start is called before the first frame update
    void Start() {
        myCharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);
        jump = Input.GetKeyDown(KeyCode.Space);


        if (turnLeft)
            transform.Rotate(new Vector3(0f, -90f, 0f));
        else if (turnRight)
            transform.Rotate(new Vector3(0f, 90f, 0f));
        if (myCharacterController.isGrounded) {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir *= speed;
            if (jump) {
                upwardVec.y = jumpSpeed;
            }
        }
        else {
            upwardVec.y += Physics.gravity.y * Time.deltaTime;
        }
            

        myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        myCharacterController.Move((transform.forward * speed + (moveDir + upwardVec)) * Time.deltaTime);
    }
}
