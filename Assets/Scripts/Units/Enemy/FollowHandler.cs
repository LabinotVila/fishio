using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowHandler : MonoBehaviour
{
    public float maxMoveSpeed = 1f;
    public float waterControlMagnitude = 1f;

    private float moveSpeed;
    private float movementMagnitude;
    private float rotation;
    public Transform objectToFollow;


    private Rigidbody2D rb;
    private Vector3 rawMovement;

    void Start()
    {
        rotation = transform.eulerAngles.z;
        movementMagnitude = 0;
        moveSpeed = maxMoveSpeed;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 relativePos = objectToFollow.position - transform.position;
        relativePos.Normalize();
        rawMovement = relativePos;
    }

    void FixedUpdate()
    {
        //Interpolation speed
        float lerpSpeed = waterControlMagnitude * Time.fixedDeltaTime;

        //Move
        GetPlayerMovement(lerpSpeed);

        //Rotate
        if (rawMovement.magnitude != 0)
            GetPlayerRotation(lerpSpeed);
    }

    void GetPlayerMovement(float lerpSpeed)
    {
        moveSpeed = Mathf.Lerp(moveSpeed, maxMoveSpeed, lerpSpeed);
        movementMagnitude = Mathf.Lerp(movementMagnitude, rawMovement.magnitude, lerpSpeed);

        rb.velocity = transform.right * movementMagnitude * moveSpeed;
    }

    void GetPlayerRotation(float lerpSpeed)
    {
        float degRotation = Mathf.Atan2(rawMovement.y, rawMovement.x) * Mathf.Rad2Deg;
        transform.eulerAngles = Vector3.forward * rotation;

        rotation = Mathf.LerpAngle(rotation, degRotation, lerpSpeed);
    }

}
