using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlockTrigger : MonoBehaviour
{
    public GameObject camera ;
    public BlueBlock blueBlock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Shake(2f, 0.1f));
            blueBlock.playerOnBlock = true;
        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = camera.transform.localPosition;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float offsetX = Random.Range(-1f, 1f) * magnitude;
            float offsetY = Random.Range(-1f, 1f) * magnitude;

            camera.transform.localPosition = originalPos + new Vector3(offsetX, offsetY, 0f);

            elapsed = elapsed+ Time.deltaTime;
            yield return null;
        }

        camera.transform.localPosition = originalPos;
    }
}
