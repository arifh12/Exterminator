using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // When Play is clicked, load the game
    public void startGame() {
        SceneManager.LoadScene(1);
    }

    // Close application when Quick is clicked
    public void quitGame() {
        Application.Quit();
    }
}
