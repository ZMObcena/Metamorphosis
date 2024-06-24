using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private float _elapsedTime;
    private int _totalPoints;

    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_GAME_OVER, this.GameOver);
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_ADD_POINTS, this.UpdatePoints);
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_WIN, this.PlayerWin);

        Time.timeScale = 1;
        this._totalPoints = 0;
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_GAME_OVER);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_ADD_POINTS);
    }

    private void Update()
    {
        this._elapsedTime += Time.deltaTime;
        Parameters timeParams = new Parameters();
        timeParams.PutExtra(EventNames.Jam1_Event.TIME_ELAPSED, this._elapsedTime);
        EventBroadcaster.Instance.PostEvent(EventNames.Jam1_Event.ON_UPDATE_TIME, timeParams);
    }

    private void UpdatePoints(Parameters param)
    {
        this._totalPoints += param.GetIntExtra(EventNames.Jam1_Event.POINTS_AMOUNT, 0);
        Parameters pointsParam = new Parameters();
        pointsParam.PutExtra(EventNames.Jam1_Event.TOTAL_POINTS, this._totalPoints);
        EventBroadcaster.Instance.PostEvent(EventNames.Jam1_Event.ON_UPDATE_POINTS, pointsParam);
        if(this._totalPoints >= 50)
        {
            EventBroadcaster.Instance.PostEvent(EventNames.Jam1_Event.ON_WIN);
        }
    }

    private void GameOver()
    {
        Time.timeScale = 0;
    }

    private void PlayerWin()
    {
        this._totalPoints = 0;
        SceneManager.LoadScene("TransitionScene");
    }
}
