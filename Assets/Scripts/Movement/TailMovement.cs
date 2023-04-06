using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class TailMovement : MonoBehaviour
{
    public Transform tailSolver;
    public Transform tailTarget;
    private Transform _body;

    private Vector3 _tailPosition;
    private Movement _movement;

    void Start()
    {
        _movement = GetComponent<Movement>();
        _body = GetComponent<Movement>().body;

        _tailPosition = tailTarget.localPosition;
    }

    void Update()
    {
        float lerpSpeed = _movement.GetWaterControlMagnitude() * Time.deltaTime;

        // get distance between tail and fish
        float distance = Vector2.Angle(tailSolver.right, _body.right);

        // move the tail up and down
        tailTarget.localPosition = _tailPosition;

        // rotate the tail based on the movement
        tailSolver.rotation = Quaternion.RotateTowards(tailSolver.rotation, _body.rotation, distance * lerpSpeed * 1.5f);
    }
}
