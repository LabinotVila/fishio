using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField]
    private float maxMoveSpeed = 5f;

    [SerializeField]
    private float waterControlMagnitude = 1f;

    private float moveSpeed;
    private float movementMagnitude;
    private float rotation;


    private Rigidbody2D rb;
    private Vector3 rawMovement = new Vector3();

    void Start()
    {
        rotation = transform.eulerAngles.z;

        movementMagnitude = 0;
        moveSpeed = maxMoveSpeed;

        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        //Interpolation speed
        float lerpSpeed = waterControlMagnitude * Time.deltaTime;

        //Move
        DoMovement(lerpSpeed);

        //Rotate
        if (rawMovement.magnitude != 0)
            DoRotation(lerpSpeed);

    }

    void DoMovement(float lerpSpeed)
    {
        moveSpeed = Mathf.Lerp(moveSpeed, maxMoveSpeed, lerpSpeed);
        movementMagnitude = Mathf.Lerp(movementMagnitude, rawMovement.magnitude, lerpSpeed);

        rb.velocity = transform.right * movementMagnitude * moveSpeed;
    }

    void DoRotation(float lerpSpeed)
    {
        float degRotation = Mathf.Atan2(rawMovement.y, rawMovement.x) * Mathf.Rad2Deg;

        transform.eulerAngles = Vector3.forward * rotation;
        rotation = Mathf.LerpAngle(rotation, degRotation, lerpSpeed);

    }

    public void SetDirection(Vector2 movement)
    {
        rawMovement = movement;
    }
    public float GetWaterControlMagnitude()
    {
        return waterControlMagnitude;
    }

}
