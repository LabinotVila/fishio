using UnityEngine;

[RequireComponent(typeof(Movement))]
public class TailMovement : MonoBehaviour
{
    public Transform tailSolver;
    private Transform _body;

    private Movement _movement;
    private const float TailReturnSpeed = 1.5f;

    private void Start()
    {
        _movement = GetComponent<Movement>();
        _body = GetComponent<Movement>().body;
    }

    private void Update()
    {
        var lerpSpeed = _movement.GetWaterControlMagnitude() * Time.deltaTime;

        var distanceTailBody = Vector2.Angle(tailSolver.right,
            _body.right);

        tailSolver.rotation = Quaternion.RotateTowards(tailSolver.rotation,
            _body.rotation,
            distanceTailBody * lerpSpeed * TailReturnSpeed);
    }
}