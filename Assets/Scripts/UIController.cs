using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] TextMeshProUGUI scoreText;

    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        handlePause();

        healthBar.value = PlayerController.health;
        scoreText.SetText(score.ToString());
    }

    // Increment the score
    public static void incrementScore(int num) {
        score += num*10;
    }

    // Handle game pause
    void handlePause() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
