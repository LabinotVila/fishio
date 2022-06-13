using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class TailMovement : MonoBehaviour
{
    public Transform tailSolver;
    public Transform tailTarget;

    public float tailMovement = 1;
    public float tailFrequency = 2;

    private Vector3 tailPosition;
    private Movement movement;

    void Start()
    {
        movement = GetComponent<Movement>();
        tailPosition = tailTarget.localPosition;
    }

    void Update()
    {
        float lerpSpeed = movement.GetWaterControlMagnitude() * Time.deltaTime;

        // get distance between tail and fish
        float distance = Vector2.Angle(tailSolver.right, transform.right);

        // move the tail up and down
        if (tailFrequency != 0 && tailMovement != 0)
            tailTarget.localPosition = tailPosition
            + Vector3.up * (Mathf.PingPong(Time.time * tailFrequency, tailMovement) - (tailMovement / 2));
        else
            tailTarget.localPosition = tailPosition;

        // rotate the tail based on the movement
        tailSolver.rotation = Quaternion.RotateTowards(tailSolver.rotation, transform.rotation, distance * lerpSpeed * 1.5f);
        tailSolver.position = transform.position;
    }
}
