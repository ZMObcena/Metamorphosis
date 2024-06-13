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
    [SerializeField] private Button _leaderboardsButton;
    [SerializeField] private Button _exitButton;

    void Start()
    {
        this._startButton.onClick.AddListener(this.OnStartButtonClicked);
        this._leaderboardsButton.onClick.AddListener(this.OnLeaderboardsButtonClicked);
        this._exitButton.onClick.AddListener(this.OnExitButtonClicked);
    }

    private void OnStartButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
    private void OnLeaderboardsButtonClicked()
    {
        Debug.Log("Leaderboards");
    }

    private void OnExitButtonClicked()
    {
        Application.Quit();
    }
}
