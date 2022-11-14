using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public string nameSceneToPlay;
    public GameObject wdMenu;
    public GameObject press;
    

    private void Start()
    {
        wdMenu.SetActive(false);
        press.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            wdMenu.SetActive(true);
            press.SetActive(false);
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(nameSceneToPlay);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void QuitMenu()
    {
        wdMenu.SetActive(false);
        press.SetActive(true);

    }
}
