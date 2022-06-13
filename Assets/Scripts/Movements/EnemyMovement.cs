using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private Movement movement;
    void Start()
    {
        movement = GetComponent<Movement>();
    }


    void Update()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        movement.SetDirection(direction);
    }
}
