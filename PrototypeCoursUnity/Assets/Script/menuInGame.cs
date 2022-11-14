using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuInGame : MonoBehaviour
{
    public string nameSceneToPlay;
    public GameObject wdMenu;
    public GameObject player;
    

    private void Start()
    {
        wdMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            wdMenu.SetActive(true);
            Cursor.visible = true;
            player.GetComponent<PlayerController>().isPaused = true;
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
        Cursor.visible = false;
        player.GetComponent<PlayerController>().isPaused = false;

    }
}
