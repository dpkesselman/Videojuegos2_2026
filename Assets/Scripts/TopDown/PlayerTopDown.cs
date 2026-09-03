using UnityEngine;

public class PlayerTopDown : MonoBehaviour
{
    // Opción 3: 8 direcciones

    [SerializeField] private float speed = 3f;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private Animator animator; // Agregamos variable Animator, componente del Inspector     
    
    [SerializeField] private float left;
    [SerializeField] private float right;
    [SerializeField] private float bottom;
    [SerializeField] private float top;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Llamamos al componente del objeto Player
    }


    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementInput = new Vector2(horizontal, vertical).normalized;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, left, right), Mathf.Clamp(transform.position.y, bottom, top), transform.position.z);

        if(Input.GetMouseButtonDown(0))
        {
           animator.SetTrigger("Shoot"); 
        }        
    }


  void FixedUpdate()
    {
        rb.MovePosition(rb.position + movementInput * speed * Time.fixedDeltaTime);
    }

}
