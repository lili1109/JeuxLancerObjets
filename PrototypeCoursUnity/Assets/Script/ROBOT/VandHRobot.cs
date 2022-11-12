using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VandHRobot : MonoBehaviour
{
    string actualScene;
    private void Start()
    {
        actualScene = SceneManager.GetActiveScene().name;
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<AISenseHearing>().AddSenseHandler(new AISense<HearingStimulus>.SenseEventHandler(HandleHearing));
        GetComponent<AISenseHearing>().AddObjectToTrack(player);
        GetComponent<AISenseSight>().AddSenseHandler(new AISense<SightStimulus>.SenseEventHandler(HandleSight));
        GetComponent<AISenseSight>().AddObjectToTrack(player);
    }
    void HandleHearing(HearingStimulus sti, AISense<HearingStimulus>.Status evt)
    {
        if (evt == AISense<HearingStimulus>.Status.Enter)
        {
            //Debug.Log("Objet " + evt + " ouïe en " + sti.Position);
            StartCoroutine(hearing());
        }
        if (evt == AISense<HearingStimulus>.Status.Leave)
        {
            //Debug.Log("Objet " + evt + " ouïe en " + sti.Position);
            StopCoroutine(hearing());
        }

    }
    void HandleSight(SightStimulus sti, AISense<SightStimulus>.Status evt)
    {
        if (evt == AISense<SightStimulus>.Status.Enter)
        {
            //Debug.Log("Objet " + evt + " vue en " + sti.position);
            StartCoroutine(seeing());
            //wantToShoot = true;
        }
        if (evt == AISense<SightStimulus>.Status.Leave)
        {
            //Debug.Log("Objet " + evt + " vue en " + sti.position);
            //wantToShoot = false;
            StopCoroutine(seeing());
        }
    }

    IEnumerator seeing()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(actualScene);
    }

    IEnumerator hearing()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(actualScene);
    }
}
