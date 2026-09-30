using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Transform player;
    public float speed = 2f;  // velocidad del enemigo
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {

        if (player != null)
        {

            Vector2 direction = (player.position - transform.position).normalized; // direccion hacia el jugador


            rb.transform.position = (Vector2)transform.position + (direction * speed * Time.deltaTime); // mueve al enemigo hacia el jugador
        }
    }
}