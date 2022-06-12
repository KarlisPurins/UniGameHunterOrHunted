using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HammerAttack : MonoBehaviour
{
    BoxCollider collider;
    private GameObject weaponObj;
    private Text cubesLeftText;
    public static int cubesLeft = 30;
    private Text youWonText;
    private Text cantKillBossText;
    public AudioSource CubeHit;

    void Start()
    {
        weaponObj = GameObject.Find("Hammer");
        cubesLeftText = GameObject.Find("CubesLeft").GetComponent<Text>();
        youWonText = GameObject.Find("YouWon").GetComponent<Text>();
        youWonText.enabled = false;
        cantKillBossText = GameObject.Find("CantKillBoss").GetComponent<Text>();
        cantKillBossText.enabled = false;

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
        if (other.gameObject.CompareTag("Enemy"))
        {
            //doDamageToCube
            PlayCubeGetHit();
            Destroy(other.gameObject);
            cubesLeft -= 1;
            cubesLeftText.text = "Evil Cubos Left: " + cubesLeft;
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            StartCoroutine(ShowCantKillBossText());
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

    IEnumerator ShowCantKillBossText()
    {
        cantKillBossText.enabled = true;
        yield return new WaitForSeconds(4);
        cantKillBossText.enabled = false;
    }

    public void PlayCubeGetHit()
    {
        CubeHit.Play();
    }
}
