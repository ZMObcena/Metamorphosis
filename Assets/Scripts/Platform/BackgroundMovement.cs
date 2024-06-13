using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        this.gameObject.transform.position += new Vector3(0, -1 * this._speed, 0) * Time.deltaTime;
    }
}
