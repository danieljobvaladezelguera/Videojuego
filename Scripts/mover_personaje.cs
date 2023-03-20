using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover_personaje : MonoBehaviour{

    public float horizontalMove; //Movimiento derecha/izquierda
    public float verticalMove; //Movimiento para saltar
    private Vector3 UserInput;
    
    public float speed ;
    private Vector3 moveUser;
    public float gravity = 9.8f;
    public float fallVelocity;
    public float jumpForce;

    public CharacterController User;
    public Camera mainCamera;

    private Vector3 camForward;
    private Vector3 camRight;

    void Start(){
        User.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update(){
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        UserInput = new Vector3(horizontalMove, 0, verticalMove);
        UserInput = Vector3.ClampMagnitude(UserInput, 1);

        camDir();

        moveUser = UserInput.x * camRight + (UserInput.z * camForward);
        
        User.transform.LookAt(User.transform.position + moveUser);


        setGravity();

        UserSkills();
        User.Move(moveUser * speed * Time.deltaTime);

        Debug.Log(User.velocity.magnitude);
        
    }

    private void FixedUpdate(){
        User.Move(new Vector3(horizontalMove, 0, verticalMove) *speed *Time.deltaTime);
    }

    public void UserSkills(){
        if (User.isGrounded && Input.GetButtonDown("Jump")){
            fallVelocity = jumpForce;
            moveUser.y = fallVelocity;
        }
    }
    void setGravity() {
        if (User.isGrounded){
            fallVelocity = -gravity * Time.deltaTime;
            moveUser.y = fallVelocity;
        }else{
            fallVelocity -= gravity * Time.deltaTime;
            moveUser.y = fallVelocity;
        }
    }
    void camDir(){
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
}
