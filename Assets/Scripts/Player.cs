using UnityEngine;

public class Player : MonoBehaviour
{
    /*Opción 1: Teclas + Transform

    [SerializeField] private float speed = 5f;
    //Acuérdense que dejamos las varias privadas a menos que querramos acceder a ellas desde otro script. 
    // Para poder settearlas desde el inspector y dejarlas privadas podemos usar SerializeField.

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * (speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * (speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * (speed * Time.deltaTime));  
        }
    }*/

    
    /* Opción 2: GetAxis + Rigidbody

    private float horizontal;
    private float speed = 8f;
    [SerializeField] private Rigidbody2D rb;


    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }


    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }
    */

    /* Opción 3: 8 direcciones

    [SerializeField] private float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 movementInput;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        movementInput = new Vector2(moveX, moveY).normalized;
    }


  void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);
    }
    */


    /* Salto (plataformas)

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }

    */


    // Salto único

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
        if (Input.GetKeyDown(KeyCode.Space) && JumpCollider.isGrounded == true)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
    }
}
