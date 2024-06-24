using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private GameObject _gameoverScreen;
    [SerializeField] private Button _replayButton;
    [SerializeField] private Button _mainmenuButton;

    [SerializeField] private GameObject _collectText;
    [SerializeField] private GameObject _avoidText;
    [SerializeField] private GameObject _movementText;

    private float _time;

    private bool _isGameOver;
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_START, this.UpdateTime);
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_GAME_OVER, this.GameOver);
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_UPDATE_TIME, this.UpdateTime);
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_UPDATE_POINTS, this.UpdatePoints);

        this._replayButton.onClick.AddListener(this.OnReplayButtonClicked);
        this._mainmenuButton.onClick.AddListener(this.OnMainMenuButtonClicked);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_START);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_GAME_OVER);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_UPDATE_TIME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_UPDATE_POINTS);
    }

    private void Update()
    {
        this._time += Time.deltaTime;

        if(this._time >= 1.5f)
        {
            this._collectText.SetActive(false);
            this._avoidText.SetActive(true);
        }

        if(this._time >= 3f)
        {
            this._avoidText.SetActive(false);
            this._movementText.SetActive(true);
        }

        if(this._time >= 5f)
        {
            this._movementText.SetActive(false);
        }
    }
    private void GameOver()
    {
        this._isGameOver = true;
        this._timeText.text = "00:00";
        this._pointsText.text = "0";

        this._gameoverScreen.SetActive(true);
    }

    private void UpdateTime(Parameters param)
    {
        if(!this._isGameOver)
        {
            float elapsedTime = param.GetFloatExtra(EventNames.Jam1_Event.TIME_ELAPSED, 0);
            this._timeText.text = $"{elapsedTime:F2}";
        }
    }

    private void UpdatePoints(Parameters param)
    {
        if(!this._isGameOver)
        {
            int points = param.GetIntExtra(EventNames.Jam1_Event.TOTAL_POINTS, 0);
            this._pointsText.text = $"{points}/50";
        }
    }

    private void OnReplayButtonClicked()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void OnMainMenuButtonClicked()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
