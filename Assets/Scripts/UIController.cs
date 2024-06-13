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

    private bool _isGameOver;
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_START, this.UpdateTime);
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_GAME_OVER, this.ResetTime);
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_GAME_OVER, this.ResetPoints);
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_UPDATE_TIME, this.UpdateTime);
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_UPDATE_POINTS, this.UpdatePoints);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_START);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_GAME_OVER);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_UPDATE_TIME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_UPDATE_POINTS);
    }

    private void UpdateTime(Parameters param)
    {
        if(!this._isGameOver)
        {
            float elapsedTime = param.GetFloatExtra(EventNames.Jam1_Event.TIME_ELAPSED, 0);
            this._timeText.text = $"{elapsedTime:F2}";
        }
    }

    private void ResetTime()
    {
        this._isGameOver = true;
        this._timeText.text = "00:00";
    }

    private void UpdatePoints(Parameters param)
    {
        if(!this._isGameOver)
        {
            int points = param.GetIntExtra(EventNames.Jam1_Event.TOTAL_POINTS, 0);
            this._pointsText.text = $"{points}/50";
        }
    }

    private void ResetPoints(Parameters param)
    {
        this._isGameOver = true;
        this._pointsText.text = "0";
    }
}
