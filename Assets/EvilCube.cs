using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCube : MonoBehaviour
{
    [Range(0f, 10f)]
    private float movementSpeed = 5f;

    [Range(0f, 300f)]
    private float closeEnoughDistance = 30.0f;
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
        StopCoroutine(lookAtPlayer());
        transform.position += Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharacterActions.sufferDamage(_player.transform.position - transform.position, other);
        }
    }

    IEnumerator lookAtPlayer()
    {
        transform.LookAt(_player.transform.position);
        yield return new WaitForSeconds(1);
    }

    IEnumerator WeirdSpawningPatrol() //It moves the cube inches to some way
    {
        yield return new WaitForSeconds(5);
        Vector3 futurePos = transform.position;
        futurePos.x += Random.Range(-2.0f, 2.0f);
        futurePos.z += Random.Range(-2.0f, 2.0f);
        futurePos.y = Terrain.activeTerrain.SampleHeight(futurePos) + 2.0f;
        transform.position = futurePos;  
    }


    public void killYourself()
    {
        Destroy(this.gameObject);
    }



}
