using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float offsetZ;
    private Vector3 m_CurrentVelocity = Vector3.zero;


    // Use this for initializatio
    private void Start()
    {
        offsetZ = transform.position.z;
    }


    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 aheadTargetPos = new Vector3(target.position.x, target.position.y, offsetZ);
        transform.position = aheadTargetPos;
    }
}
