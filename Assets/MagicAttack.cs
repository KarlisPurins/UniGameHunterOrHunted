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
        //Spawnojas nazis, bet rot�cija nav pareiza, �sten�b� tam var�tu neb�t noz�me, ja vi�� rot� lidojot.
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
