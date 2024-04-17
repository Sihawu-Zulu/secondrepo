using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AImovement : MonoBehaviour
{
    public float speed = 1f;

    public Transform target;

  


    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {



    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;

            direction.x = 0f;

            direction.z = 0f;

            direction.Normalize();

            transform.position += (direction+  new Vector3 (0,0.7f,0)).normalized * speed * Time.deltaTime;
        }
    }
}
