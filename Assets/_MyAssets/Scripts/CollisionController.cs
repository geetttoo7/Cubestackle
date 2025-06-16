using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public PlayerController movement;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }
    private void OnCollisionEnter(Collision collisionInfo)
    {
       if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            gameManager.EndGame();
        }
    }
}
