using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireObstacle : MonoBehaviour
{
    public float deactivateDuration = 6f;
    public GameObject targetObject;

    private float currentTime = 0f;
    private bool isDeactivateTime = false;

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= deactivateDuration)
        {
            isDeactivateTime = !isDeactivateTime;
            targetObject.SetActive(!isDeactivateTime);
            currentTime = 0f;
        }
    }
}
