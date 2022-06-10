using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(LineRenderer))]
public class ProceduralAnimation : MonoBehaviour
{

    // number of positions in the line renderer, higher number = smoother
    [Range(1, 50)]
    public int positionCount = 30;

    // the length of the line renderer
    [Range(1, 20)]
    public float targetLength = 10;

    // smoothDamp speed, lower value = smoother
    [Range(0.01f, 0.05f)]
    public float smoothSpeed = 0.02f;


    // animation type
    public MovementAnimation movementType = MovementAnimation.NONE;
    public float wiggleSpeed = 5;
    public float wiggleMagnitude = 20;


    private float targetDistance;
    private Transform targetDirection;
    private float startingRotation;
    private LineRenderer lineRenderer;
    private Vector3[] segmentPositions;
    private Vector3[] segmentSmoothDampPositions;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = positionCount;

        segmentPositions = new Vector3[positionCount];
        segmentSmoothDampPositions = new Vector3[positionCount];

        targetDirection = this.transform;
        targetDistance = targetLength / positionCount;
        startingRotation = targetDirection.localEulerAngles.z;

        resetSegmentPositions();
    }

    void FixedUpdate()
    {
        if (movementType == MovementAnimation.WIGGLE)
            wiggleAnimation();


        segmentPositions[0] = targetDirection.position;
        for (int position = 1; position < positionCount; position++)
        {
            // Wiggle doesn't work without adding targetDirection.right somewhere in the code
            Vector3 targetPosition = segmentPositions[position - 1] +
            (segmentPositions[position] - segmentPositions[position - 1]).normalized * targetDistance;

            segmentPositions[position] = Vector3.SmoothDamp(segmentPositions[position],
                targetPosition,
                ref segmentSmoothDampPositions[position],
                smoothSpeed);
        }
        lineRenderer.SetPositions(segmentPositions);
    }

    private void wiggleAnimation()
    {
        float wiggleRotation = Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude;
        targetDirection.localRotation = Quaternion.Euler(0, 0, startingRotation + wiggleRotation);
    }

    private void resetSegmentPositions()
    {
        segmentPositions[0] = targetDirection.position;
        for (int position = 1; position < positionCount; position++)
        {
            segmentPositions[position] = segmentPositions[position - 1] + targetDirection.right * targetDistance;
        }
        lineRenderer.SetPositions(segmentPositions);
    }
}
