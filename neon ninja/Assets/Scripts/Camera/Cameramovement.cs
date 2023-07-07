using UnityEngine;

public class Cameramovement : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 10f;
    public Vector3 offset;

        void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y) + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothPosition;
    }
}
