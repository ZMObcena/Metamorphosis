using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    void Start()
    {
        this._startButton.onClick.AddListener(this.OnStartButtonClicked);
        this._exitButton.onClick.AddListener(this.OnExitButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
