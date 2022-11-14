using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    public GameObject endGameMenu;
    private void Start()
    {
        endGameMenu.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            endGameMenu.SetActive(true);
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        }
    }
}
