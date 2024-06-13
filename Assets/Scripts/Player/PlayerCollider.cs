using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private Rigidbody _rb;
    private void Start()
    {
        this._rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Parameters pointParams = new Parameters();

        if(collision.collider.CompareTag("Obstacle"))
        {
            EventBroadcaster.Instance.PostEvent(EventNames.Jam1_Event.ON_GAME_OVER);
            this._rb.useGravity = true;
        }

        if(collision.collider.CompareTag("Leaf"))
        {
            Debug.Log("Leaf");
            pointParams.PutExtra(EventNames.Jam1_Event.POINTS_AMOUNT, 5);
            EventBroadcaster.Instance.PostEvent(EventNames.Jam1_Event.ON_ADD_POINTS, pointParams);
        }

        if (collision.collider.CompareTag("GoldLeaf"))
        {
            Debug.Log("GoldLeaf");
            pointParams.PutExtra(EventNames.Jam1_Event.POINTS_AMOUNT, 10);
            EventBroadcaster.Instance.PostEvent(EventNames.Jam1_Event.ON_ADD_POINTS, pointParams);
        }
    }
}
