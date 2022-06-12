using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowHandler : MonoBehaviour
{
    public float maxMoveSpeed = 1f;
    public float waterControlMagnitude = 1f;

    private float moveSpeed;
    private float movementMagnitude;
    private float rotation;


    private Rigidbody2D rb;
    private Vector3 rawMovement;

    // Variables regarding whether to chase the target or roam
    public Transform target;
    private float distanceWithTarget;
    private bool isRoaming;
    private float triggerDistance = 15;

    void Awake()
    {
        // Set distance to auto-roam
        distanceWithTarget = Mathf.NegativeInfinity;

        // Then we set roaming to true, because we suppose all enemies are far away
        isRoaming = true;

        // We auto start the co-routine and let all fishes roam around lead hedless dogs
        StartCoroutine(Roam());
    }

    void Start()
    {
        rotation = transform.eulerAngles.z;
        movementMagnitude = 0;
        moveSpeed = maxMoveSpeed;

        rb = GetComponent<Rigidbody2D>();
    }


    void ChaseTarget() 
    {
        Vector3 relativePos = target.position - transform.position;
        relativePos.Normalize();
        rawMovement = relativePos;
    }

    IEnumerator Roam()
    {
        float x = Random.Range(-1, 1);
        float y = Random.Range(-1, 1);
        float time = Random.Range(3, 6);

        rawMovement.x = x;
        rawMovement.y = y;


        yield return new WaitForSeconds(time);

        if (distanceWithTarget >= triggerDistance)  StartCoroutine(Roam());
    }


    void FixedUpdate()
    {
        // We keep checking for the distance between the fish and the target (the Player)
        distanceWithTarget = Vector3.Distance(transform.position, target.transform.position);

        // If distance is less than 30 (in this case), ChaseTarget() is executed in Update
        if (distanceWithTarget < triggerDistance) 
        {
            if (isRoaming) 
            {
                isRoaming = false;

                StopCoroutine(Roam());
            }

            ChaseTarget();
        } 
        else // Otherwise, set Roaming to true, this method is executed every 3 seconds (the fishes change the way they swim every 3 seconds)
        {
            if (!isRoaming) 
            {
                isRoaming = true;

                StartCoroutine(Roam());
            }
        }

        // Interpolation speed
        float lerpSpeed = waterControlMagnitude * Time.fixedDeltaTime;

        // Move
        GetPlayerMovement(lerpSpeed);

        // Rotate
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
