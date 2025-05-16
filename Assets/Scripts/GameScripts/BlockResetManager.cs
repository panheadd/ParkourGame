using System.Collections;
using UnityEngine;

public class BlockResetManager : MonoBehaviour
{
    public void ResetBlock(GameObject block, float delay)
    {
        StartCoroutine(ResetAfterDelay(block, delay));
    }

    private IEnumerator ResetAfterDelay(GameObject block, float delay)
    {
        yield return new WaitForSeconds(delay);
        block.SetActive(true);

        BlueBlock blueBlock = block.GetComponent<BlueBlock>();
        if (blueBlock != null)
        {
            blueBlock.timer = 0f;
            blueBlock.playerOnBlock = false;
        }
    }
}
