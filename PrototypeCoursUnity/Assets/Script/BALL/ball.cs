using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ball : MonoBehaviour
{
    float time = 1f;
    float timepassed;
    void Start()
    {
        timepassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timepassed  += Time.deltaTime;
        if(timepassed > time)
        {
            Destroy(gameObject);
        }
    }
}
