using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGreenBorder : MonoBehaviour
{
    public bool diasappear = false;
    public GameObject border;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(diasappear){
            border.SetActive(false);
        }
        else{
            border.SetActive(true);
        }
        
    }
}
