using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerMovement : MonoBehaviour
{
    private Movement movement;
    void Start()
    {
        movement = GetComponent<Movement>();
    }


    void Update()
    {
        Vector2 direction = new Vector2();

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        movement.SetDirection(direction);
    }
}
