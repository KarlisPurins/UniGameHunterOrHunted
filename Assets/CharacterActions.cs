using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterActions : MonoBehaviour
{
    public static int lifePoints = 10;
    private GameObject _player;
    private static float knockbackSpeed = 40.0f;
    private static Text lifeLeftText;
    private static Text youDiedText;
    private BoxCollider weaponCollider;


    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        lifeLeftText = GameObject.Find("LifeLeft").GetComponent<Text>();
        youDiedText = GameObject.Find("YouDiedText").GetComponent<Text>();
        youDiedText.enabled = false;
        weaponCollider = GameObject.Find("Hammer").GetComponent<BoxCollider>();
    }


    void Update()
    {
        if(lifePoints <= 0)
        {
            CharacterMovement.isDead = true;
            youDiedText.enabled = true;
        }
    }

    public static void sufferDamage(Vector3 direction, Collider other)
    {
        lifePoints -= 1;
        CharacterMovement.animator.Play("GetHit");
        //direction.Normalize();  //normalize direction ( values -> (0..1) )
        
        //Knockback: Not working yet
        //other.transform.position += direction * knockbackSpeed * Time.deltaTime;
        //other.gameObject.transform.position += direction * knockbackSpeed * Time.deltaTime;

        lifeLeftText.text = "Life Points Left: " + lifePoints;
    }


}
