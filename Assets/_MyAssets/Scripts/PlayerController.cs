using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    GameManager gameManager;
    Gyroscope gyro;
    bool gyroSupported;

    private void Start()
    {
        gameManager = GameManager.instance;

        gyroSupported = SystemInfo.supportsGyroscope;
        if (gyroSupported)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

#if UNITY_EDITOR
        
        if (Input.GetKey("d"))
            rb.velocity = new Vector3(sidewaysForce, rb.velocity.y, rb.velocity.z);
        else if (Input.GetKey("a"))
            rb.velocity = new Vector3(-sidewaysForce, rb.velocity.y, rb.velocity.z);
        else
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
#else
       
        if (gyroSupported)
        {
            float tilt = gyro.gravity.x; // adjust axis if needed
            rb.velocity = new Vector3(tilt * sidewaysForce * 2f, rb.velocity.y, rb.velocity.z);
        }
#endif

        if (rb.position.y < -1f)
        {
            gameManager.EndGame();
        }
    }
}
