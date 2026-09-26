using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D projectileRb;
    [SerializeField] private float speed;
    [SerializeField] private float projectileLife;
    [SerializeField] private float projectileCount;
    private PlayerTopDown playerTopDown;
    private bool mirandoDerecha;
    private bool mirandoArriba;
    
    void Start()
    {
        projectileCount = projectileLife;
        playerTopDown = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTopDown>();
        mirandoDerecha = EnemyPatrol.mirandoDerecha;
        if (mirandoDerecha)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
       
    }

    void Update()
    {
        projectileCount -= Time.deltaTime;
        if(projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (mirandoDerecha)
        {
            projectileRb.linearVelocity = new Vector2(speed, projectileRb.linearVelocity.y);
        }
        else
        {
            projectileRb.linearVelocity = new Vector2(-speed, projectileRb.linearVelocity.y);
        }
     }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
