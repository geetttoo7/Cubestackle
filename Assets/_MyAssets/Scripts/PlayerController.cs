using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.instance;
    }
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d") ) 
        {
            rb.velocity = new Vector3 (sidewaysForce, rb.velocity.y, rb.velocity.z);
        }

        else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector3 (-sidewaysForce, rb.velocity.y, rb.velocity.z);
        }

        else 
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
        }

        if (rb.position.y < -1f)
        {
            gameManager.EndGame();
        }

    }
}
