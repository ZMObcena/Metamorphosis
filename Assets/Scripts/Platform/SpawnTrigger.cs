using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] _platformPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("SpawnTrigger"))
        {
            Debug.Log("Spawn Trigger");
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        int i = Random.Range(0, this._platformPrefab.Length);
        Instantiate(this._platformPrefab[i], new Vector3(0, 118.11f, 0), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
        Debug.Log(i);
    }
}
