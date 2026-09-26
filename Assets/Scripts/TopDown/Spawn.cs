using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawn : MonoBehaviour
{    
    [SerializeField] private GameObject[] _toSpawn;
    [SerializeField] private float secondSpawn = 0.7f;
    [SerializeField] private float minTras;
    [SerializeField] private float maxTras;

    void Start()
    {
        StartCoroutine(ObjectSpawn());
    }

    void Update()
    {
        if (Score.score >= 25 && Score.score <= 50) 
        {
            secondSpawn = 0.5f;
        }

        else if (Score.score >= 51 && Score.score <= 75) 
        {
            secondSpawn = 0.4f;
        }
        
        else if (Score.score >= 76 && Score.score <100) 
        {
            secondSpawn = 0.2f;
        }
    }

    IEnumerator ObjectSpawn()
    {
        while(true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, wanted);
            GameObject objectSpawning = Instantiate(_toSpawn[Random.Range(0, _toSpawn.Length)], position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
        }
    }
}
