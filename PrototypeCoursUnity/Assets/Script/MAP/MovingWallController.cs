using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWallController : MonoBehaviour
{
    [SerializeField]
    Transform A,B, target;

    [SerializeField]
    float speed = 2;

    bool toA = true;
    // Start is called before the first frame update
    void Start()
    {
        target = A;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "target")
        {
            if (toA)
            {
                toA = false;
                target = B;
            }
            else
            {
                toA = true;
                target = A;
            }

        }
    }
}
