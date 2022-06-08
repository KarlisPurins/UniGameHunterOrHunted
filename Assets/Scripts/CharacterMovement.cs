using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Camera cmCamera;
    public CharacterController controller;
    public float speed = 10.0f;
    float gravity = -10.0f;
    private GameObject _player;
    Animator animator;

    // Update is called once per frame

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        animator = GameObject.Find("Character").GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0)){
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) //Nospiests Left Shift
        { //Characters sprinto
            speed = 15.0f;
            animator.SetBool("isRunning", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)) //Atlaists Left Shift
        { //Characters staigâ
            speed = 10.0f;
            animator.SetBool("isRunning", false);
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (z != 0) //Pârbauda, vai kustâs uz priekðu vai stâv uz vietas
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
            
        Vector3 move = transform.up * gravity + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);

    }

    public void hitEnemy()
    {

    }
}
