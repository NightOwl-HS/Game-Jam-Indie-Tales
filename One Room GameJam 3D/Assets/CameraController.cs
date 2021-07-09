using UnityEngine;
public class CameraController : MonoBehaviour{

    public Transform playerTransform;
    private Vector3 cameraOffset;

    private float rotationSpeed = 5f;
    private float smoothAmount = .5f;
    private bool lookAtPlayer = false;
    private bool rotateAroundPlayer = true;

    private void Start()
    {
        cameraOffset = transform.position - playerTransform.position;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            rotateAroundPlayer = !rotateAroundPlayer;
            lookAtPlayer = !lookAtPlayer;
        }
    }

    private void LateUpdate()
    {
        if (rotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeed, Vector3.up);
            cameraOffset = camTurnAngle * cameraOffset;
        }

        Vector3 newPos = playerTransform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothAmount);
        
        if (rotateAroundPlayer || lookAtPlayer)
        {
            transform.LookAt(playerTransform.position);
        }      
    }
}