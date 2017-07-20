using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonRigidBody : MonoBehaviour {
    Vector3 inputVector;
    Rigidbody rb;
    public float MoveSpeed = 5.0f;
    public float GravityForce = -1.0f;
    public float MouseSens = 1.0f;
    float mouseY;

	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// always put input and rendering in Update
	void Update () {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = GravityForce;
        inputVector.z = Input.GetAxis("Vertical");

        //mouse look
        transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime*MouseSens, 0f);
        mouseY -= Input.GetAxis("Mouse Y") * Time.deltaTime * MouseSens;
        mouseY = Mathf.Clamp(mouseY, -60f, 60f);
        Camera.main.transform.localEulerAngles = new Vector3(mouseY, 0f, 0f);

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

	}
    //always put physics code in FixedUpdate
    private void FixedUpdate()
    {
        Vector3 worldVector = transform.right * inputVector.x + transform.forward * inputVector.z + transform.up *inputVector.y;
        
        //rb.AddForce(worldVector * MoveSpeed,  ForceMode.VelocityChange);

        //set the velocity directly for walking
        rb.velocity = worldVector* MoveSpeed;
    }
}
