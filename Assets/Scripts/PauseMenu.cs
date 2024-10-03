using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] Button continueBtn;
    [SerializeField] Button quitBtn;

    // Start is called before the first frame update
    void Start()
    {
        continueBtn.onClick.AddListener(onClickContinue);
        quitBtn.onClick.AddListener(onClickQuit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Handle continue button click
    void onClickContinue() {
        Time.timeScale = 1.0f;
        gameObject.SetActive(false);
    }

    // Handle quit button click
    void onClickQuit() {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
