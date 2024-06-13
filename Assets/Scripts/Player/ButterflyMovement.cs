using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ButterflyMovement : MonoBehaviour
{
    [SerializeField] private Transform targetPos;
    [SerializeField] private Transform returnPos;
    [SerializeField] private float _speed;
    [SerializeField] private AnimationCurve _curveDrop;
    [SerializeField] private AnimationCurve _curveCarry;
    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_PLAYER_JUMP, this.CarryCaterpillar);
        //EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_PLAYER_FALL, this.ReturnToOriginalPosition);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_PLAYER_JUMP);
        //EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_PLAYER_FALL);
    }

    private void CarryCaterpillar()
    {
        StartCoroutine(Carry());
    }

    private void ResetPosition()
    {
        transform.position = returnPos.position;
    }
    IEnumerator Carry()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.position + Vector3.forward * 4f;

        while (elapsedTime < 0.3f)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, this._curveDrop.Evaluate(elapsedTime / 0.3f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        EventBroadcaster.Instance.PostEvent(EventNames.Jam1_Event.ON_PLAYER_FALL);

        transform.position = targetPosition;

        elapsedTime = 0f;
        startPosition = transform.position;
        targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4f);

        while (elapsedTime < 0.7f)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, this._curveCarry.Evaluate(elapsedTime / 0.7f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        elapsedTime = 0f;
        startPosition = transform.position;
        targetPosition = transform.position + Vector3.forward * 4f;

        while (elapsedTime < 0.6f)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, this._curveCarry.Evaluate(elapsedTime / 0.6f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;
        startPosition = transform.position;
        targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4f);

        while (elapsedTime < 0.56f)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, this._curveDrop.Evaluate(elapsedTime / 0.56f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        this.ResetPosition();
    }
}
