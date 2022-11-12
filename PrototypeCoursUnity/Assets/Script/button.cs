using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    [SerializeField]
    Door door;
    public bool state = false;
    Animator animator;
    public bool isOrder = false;
    public int order;
    AudioSource audioSource;
    [SerializeField]
    AudioClip sBtn;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isOrder= door.isOrder;
        if (!isOrder)
        {
            order = 0;
        }
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {

        int numbtn = door.numBtn;
        if (collision.collider.tag == "balle")
        {
            if (numbtn >= order)
            {
                state = !state;

                audioSource.PlayOneShot(sBtn);
                if (state == true)
                {
                    door.numBtn++;
                }
                if(state == false)
                {
                    
                    door.numBtn--;
                }
                animator.SetBool("button", state);
            }
        }
    }
}
