using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Elevator : MonoBehaviour
{
    
    // Start is called before the first frame update


    public Vector3 targetPosition;
    public float duration = 2f; 
    public bool start;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(start){
            transform.DOMove(targetPosition, duration);
            start = false;
        }
        
    }


}
