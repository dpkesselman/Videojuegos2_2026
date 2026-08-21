using UnityEngine;

public class Player_ : MonoBehaviour

{
    private float speed = 8f;
    private Rigidbody2D rb;
    [SerializeField] private float JumpForce = 8f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");


        rb.transform.Translate(new Vector2(horizontal, 0) * Time.deltaTime * speed);
        if (Input.GetKeyDown(KeyCode.Space) && PlayerCollider_.isGrounded == true)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}


