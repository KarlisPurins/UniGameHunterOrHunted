using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public Camera cmCamera;
    public CharacterController controller;
    private float speed = 10.0f;
    float gravity = -10.0f;
    private GameObject _player;
    public static Animator animator;
    public static bool isDead = false;
    public static bool isVictory = false;
    private Text lifePointsText;
    private Text knivesLeftText;
    private static Transform playerTransformObject;




    // Update is called once per frame

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        animator = GameObject.Find("Character").GetComponent<Animator>();
        lifePointsText = GameObject.Find("LifeLeft").GetComponent<Text>();
        knivesLeftText = GameObject.Find("KnivesLeft").GetComponent<Text>();
    }
    void Update()
    {
        playerTransformObject = transform;
        if (Input.GetKey(KeyCode.Space))
        {
            specialAttack();
        }
        if (Input.GetKey(KeyCode.RightShift)){
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

        if (isDead)
        {
            animator.Play("Death");
            stopMovement();
            hideUnneededUI();
        }
        else if (isVictory)
        {
            animator.Play("Buff");
            stopMovement();
            hideUnneededUI();
        }
        else
        {
            Vector3 move = transform.up * gravity + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        }

        
    }

    private void stopMovement()
    {
        speed = 0;
        Vector3 move = Vector3.zero;

        controller.Move(move * speed * Time.deltaTime);
    }

    private void hideUnneededUI()
    {
        lifePointsText.enabled = false;
        knivesLeftText.enabled = false;
    }

    private void specialAttack()
    {
        animator.Play("SpellCast");
    }

    public static Transform getCharTransformObject()
    {
        return playerTransformObject;
    }

}
