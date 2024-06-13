using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private void Update()
    {
        this.gameObject.transform.position += new Vector3(0, -8f, 0) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("DestroyTrigger"))
        {
            Destroy(this.gameObject);
        }
    }
}
