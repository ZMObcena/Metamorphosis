using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private AnimationCurve _curveJump;
    [SerializeField] private AnimationCurve _curveFall;

    private Rigidbody _rb;
    private bool _isGrounded;
    private bool _isJumping;
    private bool _isGameOver;

    private void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_GAME_OVER, this.StopMovement);
        EventBroadcaster.Instance.AddObserver(EventNames.Jam1_Event.ON_PLAYER_FALL, this.CallJump);
        this._rb = GetComponent<Rigidbody>();
        this._isGrounded = true;
        this._isJumping = false;
        this._isGameOver = false;
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_GAME_OVER);
        EventBroadcaster.Instance.RemoveObserver(EventNames.Jam1_Event.ON_PLAYER_FALL);
    }

    private void Update()
    {
        if(!this._isGameOver)
        {
            StickToTreeSurface();
        }

        if(Input.GetKeyDown(KeyCode.Space) && this._isGrounded)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            EventBroadcaster.Instance.PostEvent(EventNames.Jam1_Event.ON_PLAYER_JUMP);
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if(Input.GetKey(KeyCode.A) && this._isGrounded)
        {
            transform.localRotation = Quaternion.Euler(0f, 10f, 10f);
        }

        if(Input.GetKeyUp(KeyCode.A) && this._isGrounded)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if(Input.GetKey(KeyCode.D) && this._isGrounded)
        {
            transform.localRotation = Quaternion.Euler(0f, -10f, -10f);
        }

        if (Input.GetKeyUp(KeyCode.D) && this._isGrounded)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    private void StickToTreeSurface()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.forward, out hit))
        {
            Debug.DrawRay(transform.position, Vector3.forward * this._distance, Color.yellow);
            transform.position = hit.point + Vector3.back * _distance;
            this._isGrounded = true;
        }
        else
        {
            Debug.Log("Not Grounded");
            this._isGrounded = false;
        }
    }

    private void CallJump()
    {
        StartCoroutine(Jump());
    }

    IEnumerator Jump()
    {
        this._isJumping = true;
        this._isGrounded = false;

        float elapsedTime = 0f;
        elapsedTime += Time.deltaTime;

        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.position + Vector3.back * this._jumpHeight;

        while(elapsedTime < this._jumpDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, this._curveJump.Evaluate(elapsedTime / this._jumpDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;

        elapsedTime = 0f;
        startPosition = transform.position;
        targetPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + this._jumpHeight);

        while(elapsedTime < this._jumpDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, this._curveFall.Evaluate(elapsedTime / this._jumpDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        this._isJumping = false;
    }

    private void StopMovement()
    {
        Debug.Log("stop movement");
        this._isJumping = true;
        this._isGameOver = true;
    }
}

