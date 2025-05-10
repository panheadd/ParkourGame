using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstaclePingPongScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 targetPosition;
    public float duration = 2f; 

    void Start()
    {
        transform.DOMove(targetPosition, duration)
                 .SetLoops(-1, LoopType.Yoyo)
                 .SetEase(Ease.InOutSine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
