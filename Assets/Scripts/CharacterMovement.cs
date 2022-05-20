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
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.up * gravity + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);


    }
}
