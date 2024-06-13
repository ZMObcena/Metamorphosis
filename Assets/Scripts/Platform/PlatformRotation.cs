using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    private float _rotationSpeed = 40f;

    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(-Vector3.up * _rotationSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up * _rotationSpeed * Time.deltaTime);
        }
    }
}
