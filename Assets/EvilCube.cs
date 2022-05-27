using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilCube : MonoBehaviour
{
    [Range(0f, 50f)]
    [SerializeField]
    private float movementSpeed = 5f;

    [Range(0f, 10f)]
    [SerializeField]
    private float closeEnoughDistance = 10.0f;
    private float gravity = -2.0f;

    private GameObject _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player"); //Find player by tag. It can be assigned in game object inspector tag section (below name).
    }

    void Update()
    {
        print("Distance: " + Vector3.Distance(transform.position, _player.transform.position));
        if (Vector3.Distance(transform.position, _player.transform.position) > closeEnoughDistance)
        {
            stopAndStare();
        }
        else
        {
            PerformFollowPlayer();
        }
    }

    private void PerformFollowPlayer()
    {
        Vector3 direction = _player.transform.position - transform.position; // get the direction from me to player
        //direction.y += gravity;
        direction.Normalize();  //normalize direction ( values -> (0..1) )

        transform.position += direction * movementSpeed * Time.deltaTime;
    }

    private void stopAndStare()
    {
        transform.position += Vector3.zero;
        transform.Rotate(0, 1, 0);
    }
}
