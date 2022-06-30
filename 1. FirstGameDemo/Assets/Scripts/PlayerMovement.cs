using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // This is a reference to the Rigidbody argument "rb"
    public Rigidbody rb;
    public float zForce = 2000f;
    public float xForce = 500f;

    /*  We marked it as fixed update, because
        we are using it to mess with physics */

    void FixedUpdate()
    {
        // Add a forward force
        rb.AddForce(0, 0, zForce * Time.deltaTime);

        // Add a force to the right
        if(Input.GetKey("d"))
        {
            rb.AddForce(xForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Add a force to the left
        if(Input.GetKey("a"))
        {
            rb.AddForce(-xForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
