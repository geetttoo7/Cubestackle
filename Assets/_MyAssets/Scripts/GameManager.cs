using UnityEngine; 
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 

    bool gameHasEnded = false;
    public float restartDelay = 1000f;
    public GameObject completeLevelUI;

    private void Awake()
    {
        instance = this;    
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        StartCoroutine(nameof(ChangeScene));
    }
    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("GameOver!");
            StartCoroutine(nameof(RestartScene));  
        }
    }

    IEnumerator RestartScene ()
    {
        yield return new WaitForSeconds (restartDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
