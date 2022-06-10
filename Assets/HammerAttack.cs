using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerAttack : MonoBehaviour
{
    BoxCollider collider;
    private GameObject weaponObj;
    private Text cubesLeftText;
    private static int cubesLeft = 30;
    private Text youWonText;

    void Start()
    {
        weaponObj = GameObject.Find("Hammer");
        cubesLeftText = GameObject.Find("CubesLeft").GetComponent<Text>();
        youWonText = GameObject.Find("YouWon").GetComponent<Text>();
        youWonText.enabled = false;

        collider = weaponObj.GetComponent<BoxCollider>();

        collider.enabled = false;
    }

    private void Update()
    {
        if(cubesLeft <= 0) //victory condition
        {
            youWonText.enabled = true;
            CharacterMovement.isVictory = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print("collision with hammer");
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("damage to cube");
            //doDamageToCube
            Destroy(other.gameObject);
            cubesLeft -= 10;
            cubesLeftText.text = "Evil Cubos Left: " + cubesLeft;
        }


    }

    public void startDamage()
    {
        collider.enabled = true;
    }

    public void endDamage()
    {
        collider.enabled = false;
    }
}
