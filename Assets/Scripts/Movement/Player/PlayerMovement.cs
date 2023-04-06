using UnityEngine;
using Vector2 = UnityEngine.Vector2;

[RequireComponent(typeof(Movement))]
public class PlayerMovement : MonoBehaviour
{
    private Movement _movement;
    public Joystick joystick;

    private void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        Vector2 direction = new Vector2();

        direction = joystick ? MoveWithJoystick(direction) : MoveWithKeys(direction);

        _movement.SetDirection(direction);
    }

    private Vector2 MoveWithJoystick(Vector2 direction)
    {
        direction.x = joystick.Horizontal;
        direction.y = joystick.Vertical;

        return direction;
    }

    private Vector2 MoveWithKeys(Vector2 direction)
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        return direction;
    }
}