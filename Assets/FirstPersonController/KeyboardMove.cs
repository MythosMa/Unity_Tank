using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class KeyboardMove : MonoBehaviour {

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private CharacterController _charController ;
    private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
        _charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        //float deltaX = Input.GetAxis("Horizontal") * speed;
        //float deltaZ = Input.GetAxis("Vertical") * speed;

        //Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        //movement = Vector3.ClampMagnitude(movement, speed);
        ////movement.y = gravity;
        //movement *= Time.deltaTime;
        //movement = transform.TransformDirection(movement);
        //_charController.Move(movement);

        if (_charController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        _charController.Move(moveDirection * Time.deltaTime);
	}
}
