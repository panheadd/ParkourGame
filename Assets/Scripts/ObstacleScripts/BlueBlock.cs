using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : MonoBehaviour
{

    public float timeBeforeFall = 2f;
    public bool playerOnBlock = false;
    public float timer = 0f;
    public BlockResetManager resetManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame

    private void Update()
    {
        if (playerOnBlock)
        {
            timer = timer + Time.deltaTime;
            if (timer >= timeBeforeFall)
            {
                resetManager.ResetBlock(gameObject, 5.0f);
                gameObject.SetActive(false);
            }
        }
    }

    IEnumerator ResetBlockAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay);
    timer = 0f;
    playerOnBlock = false;
    gameObject.SetActive(true);
}


}
