using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerAttack : MonoBehaviour
{
    BoxCollider collider;
    private GameObject weaponObj;
    // Start is called before the first frame update
    void Start()
    {
        weaponObj = GameObject.Find("Hammer");
        collider = weaponObj.GetComponent<BoxCollider>();

        collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("collision with hammer");
        if (other.gameObject.CompareTag("Enemy"))
        {
            print("damage to cube");
            //doDamageToCube
            Destroy(other.gameObject);
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
