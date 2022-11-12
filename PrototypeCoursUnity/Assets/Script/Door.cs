using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    AudioClip sDoor;
    [SerializeField]
    List<GameObject> button = new List<GameObject>();
    Animator animator;
    bool state = false;
    int nbButton;
    public bool isOrder= false;
    public int numBtn = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (!isOrder)
        {
            numBtn = 0;
        }
        nbButton = button.Count;
        animator = GetComponent<Animator>();
    }     // Update is called once per frame
    void Update()
    {
        int k = 0;
        foreach(var button in button)
        {
           if(button.GetComponent<button>().state == true)
            {
                k++;
            }
        }
        if (k == nbButton)
        {
            animator.SetBool("isOpen", true);
            //audioSource.PlayOneShot(sDoor);
            state = true;
        }
        if(state == true && k < nbButton)
        {
            animator.SetBool("isOpen", false);
            state = false;
            //audioSource.Play();
        }
    }
}
