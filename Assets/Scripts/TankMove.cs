using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMove : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public float rotateSpeed = 1.0f;

    private Rigidbody rigidBody;
    // Use this for initialization
    void Start () {
        rigidBody = this.GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    private void Update()
    {
        float moveInput = Input.GetAxis(Const.Vertical);
        Vector3 position = transform.position;
        if(moveInput != 0)
        {
            position += moveInput * moveSpeed * Time.deltaTime * transform.forward;
            transform.position = position;
        }

        float rotateInput = Input.GetAxis(Const.Horizontal);
        if(rotateInput != 0)
        {
            transform.Rotate(rotateInput * Vector3.up * rotateSpeed, Space.World);
        }
    }
}
