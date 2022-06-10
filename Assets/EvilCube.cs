using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCube : MonoBehaviour
{
    [Range(0f, 10f)]
    [SerializeField]
    private float movementSpeed = 5f;

    [Range(0f, 300f)]
    [SerializeField]
    private float closeEnoughDistance = 10.0f;
    private float gravity = 0.2f; //gravity is positive, so they float just above ground and not in ground
    private float distanceToPlayer = 0.0f; 

    private GameObject _player;


    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player"); //Find player by tag. It can be assigned in game object inspector tag section (below name).
    }

    void Update()
    {
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
            CharacterActions.sufferDamage(_player.transform.position - transform.position, other);
        }
    }
}
