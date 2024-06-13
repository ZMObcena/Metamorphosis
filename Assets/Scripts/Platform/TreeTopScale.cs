using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTopScale : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.localScale += new Vector3(0.001f, 0.001f, 0.001f) * Time.deltaTime;
    }
}
