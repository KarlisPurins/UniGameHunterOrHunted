using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicAttack : MonoBehaviour
{
    private GameObject knifeOrigin;
    private GameObject knife = null;
    private Vector3 endPosition;
    private float timeToArrive = 5;
    private Text cubesLeftText;
    private Text knivesLeftText;
    private Text noMoreKnivesText;
    private Text cantShootText;
    private int knivesLeft = 4;
    private bool canShoot = true;
    private Text cantKillBossText;
    public AudioSource knifeKill;

    private void Start()
    {
        knifeOrigin = GameObject.Find("office_knife").gameObject;
        cubesLeftText = GameObject.Find("CubesLeft").GetComponent<Text>();
        knivesLeftText = GameObject.Find("KnivesLeft").GetComponent<Text>();
        noMoreKnivesText = GameObject.Find("NoMoreKnives").GetComponent<Text>();
        noMoreKnivesText.enabled = false;
        cantShootText = GameObject.Find("CantShoot").GetComponent<Text>();
        cantShootText.enabled = false;

        cantKillBossText = GameObject.Find("CantKillBoss").GetComponent<Text>();
        cantKillBossText.enabled = false;
    }

    public void shootBall()
    {
        if (knivesLeft > 0)
        {
            if (canShoot)
            {
                Vector3 charPos = CharacterMovement.getCharTransformObject().position;
                Quaternion charRot = CharacterMovement.getCharTransformObject().rotation;
                charRot.w += 0.9f;
                knife = Instantiate(knifeOrigin, charPos, charRot);

                knivesLeft -= 1;
                knivesLeftText.text = "Knives left: " + knivesLeft;
                StartCoroutine(flyKnifeFly(charPos));
            }
            else
            {
                StartCoroutine(ShowCantShoot());
            }
        }
        else
        {
            StartCoroutine(ShowNoMoreKnives());
        }
        
    }

    IEnumerator flyKnifeFly(Vector3 startPos)
    {
        startPos.y = Terrain.activeTerrain.SampleHeight(startPos) + 2.0f;
        knife.transform.forward = CharacterMovement.getCharTransformObject().forward;
        Quaternion startRot = knife.transform.rotation;
        Quaternion endRot = startRot;

        float timePercentage = 0f;
        while (timePercentage < 1)
        {
            canShoot = false;
            timePercentage += Time.deltaTime / timeToArrive;
            endPosition = startPos;
            endPosition += knife.transform.forward * 10;
            knife.transform.position = Vector3.Lerp(startPos, endPosition, timePercentage);
            yield return null;
        }
        if(timePercentage >= 0.9f)
        {
            canShoot = true;
            Destroy(knife.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //doDamageToCube
            knifeKill.Play();
            Destroy(other.gameObject);
            HammerAttack.cubesLeft -= 1;
            cubesLeftText.text = "Evil Cubos Left: " + HammerAttack.cubesLeft;
        }
        if (other.gameObject.CompareTag("Boss"))
        {
            StartCoroutine(ShowCantKillBossText());
        }
    }


    IEnumerator ShowNoMoreKnives()
    {
        noMoreKnivesText.enabled = true;
        yield return new WaitForSeconds(3);
        noMoreKnivesText.enabled = false;
    }

    IEnumerator ShowCantShoot()
    {
        cantShootText.enabled = true;
        yield return new WaitForSeconds(3);
        cantShootText.enabled = false;
    }

    IEnumerator ShowCantKillBossText()
    {
        cantKillBossText.enabled = true;
        yield return new WaitForSeconds(4);
        cantKillBossText.enabled = false;
    }


}
