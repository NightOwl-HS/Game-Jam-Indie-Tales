using UnityEngine;
public class CameraController : MonoBehaviour
{

    public Transform playerTransform;
    private Vector3 cameraOffset;

    public static CameraController Instance;

    private bool followed = false;

    private float rotationSpeed = 5f;
    private float smoothAmount = .5f;
    private bool lookAtPlayer = false;
    private bool rotateAroundPlayer = true;

    public void SetFollowTransform(Transform trans)
    {
        playerTransform = trans;
    }


    private void Start()
    {
        Instance = this;
        Debug.Log(playerTransform.position);
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        cameraOffset = transform.position - playerTransform.position;
    }
    private void Update()
    {

        if (!followed && playerTransform)
        {
            cameraOffset = transform.position - playerTransform.position;
            followed = true;
        }

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

        if (playerTransform)
        {
            Vector3 newPos = playerTransform.position + cameraOffset;
            transform.position = Vector3.Slerp(transform.position, newPos, smoothAmount);

            if (rotateAroundPlayer || lookAtPlayer)
            {
                transform.LookAt(playerTransform.position);
            }
        }
    }
}