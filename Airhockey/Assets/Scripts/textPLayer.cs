using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textPLayer : MonoBehaviour
{
    public Transform position;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = position.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
