using UnityEngine;


public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D projectileRb;
    [SerializeField] private float speed;
    [SerializeField] private float projectileLife;
    [SerializeField] private float projectileCount;
   
    void Start()
    {
        projectileCount = projectileLife;
    }


    void Update()
    {
        projectileCount -= Time.deltaTime;
        if(projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

