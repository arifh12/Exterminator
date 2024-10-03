using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] Button retryBtn;
    [SerializeField] Button quitBtn;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        retryBtn.onClick.AddListener(restartGame);
        quitBtn.onClick.AddListener(quitGame);

        scoreText.SetText("Score: " + PlayerPrefs.GetInt("Score") + "\n" + "High Score: " + PlayerPrefs.GetInt("HighScore"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Restart the game on Retry click
    void restartGame() {
        SceneManager.LoadScene(1);
    }

    // Return to start screen on Quit
    void quitGame() {
        SceneManager.LoadScene(0);
    }
}
