using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private float shootTime; 
    [SerializeField] private float shootCounter; 


    void Start()
    {
        shootCounter = shootTime;  
    }


    void Update()
    {
        if (shootCounter <= 0)
        {
            Instantiate(projectilePrefab, launchPoint.position + launchPoint.forward + launchPoint.up, launchPoint.rotation);
            // Instantiate = spawn. Toma tres valores:
            // 1. Qué vas a instanciar - 2. Dónde lo vas a isntanciar - 3. Qué rotación va a tener el objeto

            shootCounter = shootTime;
        }        


        shootCounter -= Time.deltaTime; // Hace que el enfriamiento cuente hacia abajo
    }

}
