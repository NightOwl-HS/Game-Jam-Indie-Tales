using UnityEngine;

public class Arrow : MonoBehaviour{

    private Rigidbody rb;

    private BoxCollider boxCol;

    public TrailRenderer trailRend;

    bool hitSomething = false;

    private float moveSpeed;

    float hitDepth = 0.1f;

    private float rotateAmount = 180f;


    private void Start(){
        rb = GetComponent<Rigidbody>();
        boxCol = GetComponent<BoxCollider>();
    }
    public void Setup(float value) 
    {
        moveSpeed = value;
    }

    private void Update()
    {
        if (!hitSomething)
        {
            transform.Rotate(rotateAmount * Time.deltaTime, 0, 0);
        }
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
            if (other.gameObject.CompareTag("Button"))
            {
                ArrowStick(other);
                hitSomething = true;
                PressableButton but = other.gameObject.GetComponent<PressableButton>();
                but.PressButton();
            }

            if (other.gameObject.CompareTag("Wall"))
            {
                ArrowStick(other);
                hitSomething = true;
            }


            ArrowStick(other);
            hitSomething = true;
        }
    }
    void ArrowStick(Collider col)
    {
        Destroy(boxCol);
        Destroy(rb);
        trailRend.enabled = false;
        transform.Translate(hitDepth * -Vector2.right);
        GameObject tempObject = new GameObject();
        tempObject.transform.parent = col.transform;
        transform.parent = tempObject.transform;
        Debug.Log("Yeet!");
        Destroy(gameObject, 200f);
    }
}