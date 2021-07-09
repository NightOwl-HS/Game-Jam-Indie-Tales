using UnityEngine;

public class Arrow : MonoBehaviour{
    private Rigidbody rb;
    private BoxCollider boxCol;
    private float moveSpeed;
    bool hitSomething = false;
    float hitDepth = 0.30f;

    private void Start(){
        rb = GetComponent<Rigidbody>();
    }
    public void Setup(float value) 
    {
        moveSpeed = value;
    }

    private void FixedUpdate(){
        MoveArrow();
    }

    private void MoveArrow(){
        if (!rb) return;
        rb.velocity = -transform.right * moveSpeed * Time.deltaTime;
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) return;
        if (!hitSomething)
        {
            ArrowStick(other);
            hitSomething = true;
        }
    }
    void ArrowStick(Collider col)
    {
        //BUTTON if(col.gameObject.GetComponent(""))
        col.transform.Translate(hitDepth * -Vector2.right);
        transform.parent = col.transform;
        Destroy(rb);
        Destroy(boxCol);
        Debug.Log("Yeet!");
        Destroy(gameObject, 5f);
    }
}