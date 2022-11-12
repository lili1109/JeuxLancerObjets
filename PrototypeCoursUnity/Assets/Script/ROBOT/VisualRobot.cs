using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class VisualRobot : Robot
{
    public string actualScene;
    private void Start()
    {
        actualScene = SceneManager.GetActiveScene().name;
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GetComponent<AISenseSight>().AddSenseHandler(new AISense<SightStimulus>.SenseEventHandler(HandleSight));
        GetComponent<AISenseSight>().AddObjectToTrack(player);
    }
    // Update is called once per frame
    void Update()
    {
       
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
}
