using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HearingRobot : Robot
{
    string actualScene;
    private void Start()
    {
        actualScene = SceneManager.GetActiveScene().name;
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<AISenseHearing>().AddSenseHandler(new AISense<HearingStimulus>.SenseEventHandler(HandleHearing));
        GetComponent<AISenseHearing>().AddObjectToTrack(player);
    }
    void HandleHearing(HearingStimulus sti, AISense<HearingStimulus>.Status evt)
    {
        if (evt == AISense<HearingStimulus>.Status.Enter)
        {
            //Debug.Log("Objet " + evt + " ou�e en " + sti.Position);
            StartCoroutine(hearing());
        }
        if (evt == AISense<HearingStimulus>.Status.Leave)
        {
            //Debug.Log("Objet " + evt + " ou�e en " + sti.Position);
            StopCoroutine(hearing());
        }

    }

    IEnumerator hearing()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(actualScene);
    }
}
