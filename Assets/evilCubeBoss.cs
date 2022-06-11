using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilCubeBoss : MonoBehaviour
{
    [Range(0f, 10f)]
    private float movementSpeed = 7f;

    [Range(0f, 300f)]
    private float closeEnoughDistance = 1000.0f;
    private float gravity = 0.2f; //gravity is positive, so they float just above ground and not in ground
    private float distanceToPlayer = 0.0f;

    private GameObject _player;


    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player"); //Find player by tag. It can be assigned in game object inspector tag section (below name).
    }

    void Update()
    {
        if (CharacterMovement.isDead)
        {
            killYourself();
        }
        if(HammerAttack.cubesLeft <= 1)
        {
            this.tag = "Enemy";
        }
        distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        if (distanceToPlayer < closeEnoughDistance)
        {
            PerformFollowPlayer();
        }
        else
        {
            stopAndStare();
        }
    }

    private void PerformFollowPlayer()
    {
        StartCoroutine(lookAtPlayer());
        Vector3 direction = _player.transform.position - transform.position; // get the direction from me to player

        direction.Normalize();//normalize direction ( values -> (0..1) )
        direction.y += gravity;

        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    private void stopAndStare()
    {
        transform.position += Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharacterActions.lifePoints = 0;
        }
    }


    IEnumerator lookAtPlayer()
    {
        transform.LookAt(_player.transform.position);
        yield return new WaitForSeconds(1.0f);
    }

    public void killYourself()
    {
        Destroy(this.gameObject);
    }

}

