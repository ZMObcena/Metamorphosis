using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform start;  
    [SerializeField] private Transform end;   
    [SerializeField] private float duration = 5f; 
    private float elapsedTime = 0f; 

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        transform.position = Vector3.Lerp(start.position, end.position, Mathf.SmoothStep(0f, 1f, t));

        if(elapsedTime >= 8f)
        {
            SceneManager.LoadScene("ButterflyScene");
        }
    }
}