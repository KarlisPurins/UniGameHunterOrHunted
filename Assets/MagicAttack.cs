using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAttack : MonoBehaviour
{
    private GameObject knife;

    private void Start()
    {
        knife = GameObject.Find("office_knife").gameObject;
    }

    public void shootBall()
    {
        //Spawnojas nazis, bet rotâcija nav pareiza, îstenîbâ tam varçtu nebût nozîme, ja viòð rotç lidojot.
        Vector3 charPos = CharacterMovement.getCharTransformObject().position;
        print(CharacterMovement.getCharTransformObject().rotation);
        Quaternion charRot = knife.transform.rotation; //CharacterMovement.getCharTransformObject().rotation;
        print(charRot);
            //charRot.y -= 0.9f;
        //charRot.w += 0.9f;
        charPos.x += 2.0f;
        Instantiate(knife, charPos, charRot);
        print("ballShootz");
    }


}
