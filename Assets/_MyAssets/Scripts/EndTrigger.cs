using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    void OnTriggerEnter()
    {
        gameManager.CompleteLevel();
    }
}
