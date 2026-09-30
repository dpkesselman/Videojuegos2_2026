using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemigoPrefab; // Prefab del enemigo
    [SerializeField] private Transform jugador;   // Referencia al objeto del jugador
    [SerializeField] private float intervaloDeSpawn = 3f; // Intervalo de tiempo entre spawns
    [SerializeField] private float distanciaDeSpawn = 5f; // Distancia desde el jugador donde spawnearán los enemigos
    
    [SerializeField] private float left;
    [SerializeField] private float right;
    [SerializeField] private float bottom;
    [SerializeField] private float top;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player")?.transform; // Buscar el objeto del jugador
        if (jugador == null) { 
            Debug.LogError("No se encontró el objeto del jugador."); 
            return; 
        }
        StartCoroutine(SpawnEnemigos()); // Iniciar la corrutina para spawnear enemigos
    }

    private IEnumerator SpawnEnemigos()
    {
        while (true)
        {

            if (jugador == null) { yield break; }

            for (int i = 0; i < 1; i++)
            {
                Vector3 spawnPosition = jugador.position + (Vector3)(Random.insideUnitCircle.normalized * distanciaDeSpawn);
                Instantiate(enemigoPrefab[i], spawnPosition, Quaternion.identity);
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, left, right), Mathf.Clamp(transform.position.y, bottom, top), transform.position.z);
            }
            yield return new WaitForSeconds(intervaloDeSpawn); // Esperar 3 segundos antes de spawnear de nuevo
        }
    }
}