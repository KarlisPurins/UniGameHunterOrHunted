using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Camera cmCamera;
    public CharacterController controller;
    public float speed = 10.0f;
    float gravity = -10.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 15.0f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 10.0f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.up * gravity + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

    }
}
