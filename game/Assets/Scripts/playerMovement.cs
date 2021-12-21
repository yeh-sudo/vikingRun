using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour {

    bool alive = true;

    [SerializeField] private float speed = 9.0f;
    private bool turnLeft, turnRight, jump, forward;
    private CharacterController myCharacterController;
    private float jumpSpeed = 9.0f;
    private float ySpeed = -1.0f;
    private Vector3 upwardVec;
    private Vector3 moveDir;


    private Animator anim;
    private bool isJumping;
    private bool isGrounded;
    private bool isRunning = false;


    // Start is called before the first frame update
    void Start() {
        myCharacterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

        if (!alive) {
            return;
        }

        turnLeft = Input.GetKeyDown(KeyCode.A);
        turnRight = Input.GetKeyDown(KeyCode.D);
        forward = Input.GetKeyDown(KeyCode.W);
        jump = Input.GetKeyDown(KeyCode.Space);

        if (forward) {
            isRunning = true;
            anim.SetBool("Running", true);
        }

        if (!isRunning) {
            return;
        }
        else {
            anim.SetBool("Running", true);
        }

        if (turnLeft)
            transform.Rotate(new Vector3(0f, -90f, 0f));
        else if (turnRight)
            transform.Rotate(new Vector3(0f, 90f, 0f));
        if (myCharacterController.isGrounded) {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir *= speed;
            anim.SetBool("isGrounded", true);
            isGrounded = true;
            anim.SetBool("isJumping", false);
            isJumping = false;
            if (jump) {
                upwardVec.y = jumpSpeed;
                anim.SetBool("isJumping", true);
                isJumping = true;
                anim.SetBool("isGrounded", false);
                isGrounded = false;
            }
        }
        else {
            upwardVec.y += Physics.gravity.y * Time.deltaTime;
        }
            

        myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        myCharacterController.Move((transform.forward * speed + (moveDir + upwardVec)) * Time.deltaTime);

        if (transform.position.y < -10) {
            die();
        }
    }

    public void die() {
        alive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
