using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TMP_Text scoreText;
    
    void Update()
    {
        scoreText.text = player.position.z.ToString("0");
    }
}
