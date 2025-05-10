using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstaclePiston : MonoBehaviour
{
    public Vector3 pushOffset = new Vector3(0, 0, 1f); 
    private Vector3 initialPosition;
    // Start is called before the first frame update

    void Start()
    {
        initialPosition = transform.position;

        Sequence pistonSequence = DOTween.Sequence();

        pistonSequence.Append(transform.DOMove(initialPosition + pushOffset, 0.5f)) 
                      .Append(transform.DOMove(initialPosition, 0.5f))               
                      .AppendInterval(2f)                                           
                      .SetLoops(-1);                                                
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
