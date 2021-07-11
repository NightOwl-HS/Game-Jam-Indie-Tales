using UnityEngine;

public class PlayerBase : MonoBehaviour{

    public GameObject arrowPrefab;
    public Transform shootPosition;
    public Transform orientation;
    private float arrowMoveSpeed = 1000f;

    public Animator anim;



    private void Update()
    {
        if (Input.GetMouseButtonDown(1)){
            ShootArrow();
        }
    }

    private void ShootArrow()
    {
        Quaternion tempRot = orientation.rotation;
        tempRot *= Quaternion.Euler(0, 90, 0);
        GameObject tempArrow = Instantiate(arrowPrefab, shootPosition.position, tempRot);
        tempArrow.GetComponent<Arrow>().Setup(arrowMoveSpeed);
    }
}
