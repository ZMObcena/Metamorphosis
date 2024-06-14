using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    private float _speed = 100f;

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.localEulerAngles = new Vector3(0, 1 * _speed, 0) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.localEulerAngles = new Vector3(0, -1 * _speed, 0) * Time.deltaTime;
        }
    }
}
