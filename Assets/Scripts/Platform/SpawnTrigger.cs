using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject[] _platformPrefab;
    [SerializeField] private GameObject[] _stickPrefab;
    [SerializeField] private GameObject[] _leafPrefab;

    private void OnTriggerEnter(Collider other)
    {
        int num = Random.Range(3, 6);
        if(other.gameObject.CompareTag("SpawnTrigger"))
        {
            Debug.Log("Spawn Trigger");
            SpawnPlatform();
            for(int i = 0; i < num; i++)
            {
                SpawnSticks();
                SpawnLeaves();
            }
        }
    }

    private void SpawnPlatform()
    {
        int i = Random.Range(0, this._platformPrefab.Length);
        Instantiate(this._platformPrefab[i], new Vector3(0, 118.11f, 0), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
        Debug.Log(i);
    }

    private void SpawnSticks()
    {
        int i = Random.Range(0, this._stickPrefab.Length);
        Instantiate(this._stickPrefab[i], new Vector3(0, 200f, 0), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
    }

    private void SpawnLeaves()
    {
        int i = Random.Range(0, this._leafPrefab.Length);
        Instantiate(this._leafPrefab[i], new Vector3(0, 120f, 0), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
    }
}
