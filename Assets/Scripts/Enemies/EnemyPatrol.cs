using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    [SerializeField] private float speed;


    // Persecución
    [SerializeField] private Transform playerTransform;
    private bool isChasing;
    public float chaseDistance; //se declaran fuera del update para poder usarla en otro clase
    public float distanciaAlJugador; //esta tambien
    [SerializeField] private float stopChaseDistance = 4f; // Para que deje de perseguir si el jugador se aleja


    private Vector2 direccionMovimiento;
    public static bool mirandoDerecha = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform; // Empezamos yendo hacia el punto B
    }


    void Update()
    {
        distanciaAlJugador = Vector2.Distance(transform.position, playerTransform.position);


        // Lógica de transición de estados
        if (!isChasing && distanciaAlJugador < chaseDistance)
        {
            isChasing = true;
        }
        else if (isChasing && distanciaAlJugador > stopChaseDistance)
        {
            isChasing = false;
            // Al volver a patrullar, busca el punto más cercano para no cruzar todo el mapa
            currentPoint = (Vector2.Distance(transform.position, pointA.transform.position) < Vector2.Distance(transform.position, pointB.transform.position)) ? pointA.transform : pointB.transform;
        }


        // Cálculo de direcciones (No aplica movimiento físico aquí)
        if (isChasing)
        {
            float dirX = playerTransform.position.x - transform.position.x;
            direccionMovimiento = new Vector2(Mathf.Sign(dirX), 0);
        }
        else
        {
            // Calcula la dirección exacta hacia el punto actual (A o B)
            float dirX = currentPoint.position.x - transform.position.x;
            direccionMovimiento = new Vector2(Mathf.Sign(dirX), 0);


            // Verifica si llegó al punto usando una tolerancia de 0.5f
            if (Mathf.Abs(transform.position.x - currentPoint.position.x) < 0.5f)
            {
                if (currentPoint == pointA.transform)
                {
                    currentPoint = pointB.transform;
                    Debug.Log("Cambiando destino al Punto B");
                }
                else
                {
                    currentPoint = pointA.transform;
                    Debug.Log("Cambiando destino al Punto A");
                }
            }
        }


        // Control del giro (Flip) visual
        if (direccionMovimiento.x > 0 && !mirandoDerecha) Flip();
        else if (direccionMovimiento.x < 0.1 && mirandoDerecha) Flip();
    }


    void FixedUpdate()
    {
        // Aplica el movimiento de forma fluida respetando las físicas de Unity
        rb.linearVelocity = new Vector2(direccionMovimiento.x * speed, rb.linearVelocity.y);
    }


    private void Flip()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }


    private void OnDrawGizmos()
    {
        if (pointA != null && pointB != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
            Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
            Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
        }
       
        if (playerTransform != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
