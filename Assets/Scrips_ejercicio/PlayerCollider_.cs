using UnityEngine;


public class PlayerCollider_ : MonoBehaviour
{
    public static bool isGrounded;    


    void Start()
    {
        isGrounded = false;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground2"))
        {
            isGrounded = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground2"))
        {
            isGrounded = false;
        }
    }
}
