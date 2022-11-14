using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public string nameSceneToPlay;
    public GameObject wdMenu;

    private void Start()
    {
        wdMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            wdMenu.SetActive(true);
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
    }
}
