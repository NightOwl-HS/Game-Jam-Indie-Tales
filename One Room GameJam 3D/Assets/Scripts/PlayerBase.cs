using UnityEngine;

public class PlayerBase : MonoBehaviour{

    public GameObject arrowPrefab;
    public Transform shootPosition;
    public Transform orientation;
    private float arrowMoveSpeed = 1000f;

    public static PlayerBase Instance;

    private Animator anim;
    private PlayerController controller;

    private void Start()
    {
        Instance = this;
        anim = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
    }

    public void SetPlayerCameraTransform(Transform cam)
    {
        controller = GetComponent<PlayerController>();
        controller.SetCamera(CameraController.Instance.transform);
    }

    private void Update()
    {
        PlayRunAnimation(controller.IsPlayerRunning());


        if (Input.GetMouseButtonDown(1)){
            ShootArrow();
            anim.SetTrigger("Shoot_Arrow");
        }
    }

    private void ShootArrow()
    {
        Quaternion tempRot = orientation.rotation;
        tempRot *= Quaternion.Euler(0, 90, 0);
        GameObject tempArrow = Instantiate(arrowPrefab, shootPosition.position, tempRot);
        tempArrow.GetComponent<Arrow>().Setup(arrowMoveSpeed);
        AudioManager.Instance.PlaySound("ArrowShootClip");
    }

    private void PlayRunAnimation(bool ready)
    {
        if (ready)
        {
            anim.SetBool("Running", true);
        }else if (!ready)
        {
            anim.SetBool("Running", false);
        }
    }
}
