using System.Collections.Generic;
using Attributes;
using UnityEngine;

[RequireComponent(typeof(Stats))]
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public Transform body;
    public float waterControlMagnitude = 1f;

    private float _moveSpeed;
    private float _movementMagnitude;
    private float _rotation;

    private Rigidbody2D _rigidbody2D;
    private Vector3 _rawMovement;

    private Dictionary<Type, ValueGrowth> attributesAttacher;

    private void Start()
    {
        attributesAttacher = GetComponent<Stats>().GetStats();

        _rotation = transform.eulerAngles.z;

        _movementMagnitude = 0;
        _moveSpeed = attributesAttacher[Type.Speed].GetValue();

        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        var interpolationSpeed = waterControlMagnitude * Time.deltaTime;

        DoMovement(interpolationSpeed);

        if (_rawMovement.magnitude != 0)
            DoRotation(interpolationSpeed);

        _rigidbody2D.angularVelocity = 0;
    }

    private void DoMovement(float interpolationSpeed)
    {
        _moveSpeed = Mathf.Lerp(_moveSpeed, attributesAttacher[Type.Speed].GetValue(), interpolationSpeed);
        _movementMagnitude = Mathf.Lerp(_movementMagnitude, _rawMovement.magnitude, interpolationSpeed);

        _rigidbody2D.velocity = body.right * (_movementMagnitude * _moveSpeed);
    }

    private void DoRotation(float interpolationSpeed)
    {
        var degRotation = Mathf.Atan2(_rawMovement.y, _rawMovement.x) * Mathf.Rad2Deg;

        body.eulerAngles = Vector3.forward * _rotation;
        _rotation = Mathf.LerpAngle(_rotation, degRotation, interpolationSpeed);
    }

    public void SetDirection(Vector2 movement)
    {
        _rawMovement = movement;
    }

    public float GetWaterControlMagnitude()
    {
        return waterControlMagnitude;
    }
}