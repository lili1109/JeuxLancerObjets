using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class AISense<Stimulus> : MonoBehaviour
{
    public enum Status
    {
        Enter,
        Stay,
        Leave
    };
   
    public Transform SenseTransform;

    public float updateInterval = 0.3f;
    private float updateTime = 0.0f;

    public bool ShowDebug = true;
    protected List<Transform> trackedObjects = new List<Transform>();
    protected List<Transform> sensedObjects = new List<Transform>();

    public delegate void SenseEventHandler(Stimulus sti, Status sta);

    private event SenseEventHandler CallSenseEvent;

    // Update is called once per frame
    void Update()
    {
        Stimulus stimulus;
        Status sta = Status.Stay;
      
        updateTime += Time.deltaTime;
        if(updateTime > updateInterval)
        {
            resetSense();

            foreach(Transform t in trackedObjects)
            {
                stimulus = default(Stimulus);
                if(doSense(t,ref stimulus))
                {
                    sta = Status.Stay;
                    if (!sensedObjects.Contains(t))
                    {
                        sensedObjects.Add(t);
                        sta = Status.Enter;
                    }
                    CallSenseEvent(stimulus, sta);
                }
                else
                {
                    if (sensedObjects.Contains(t))
                    {
                        sta = Status.Leave;
                        CallSenseEvent(stimulus, sta);
                        sensedObjects.Remove(t);
                    }
                }
            }
            updateTime = 0;
        }
    }

    protected abstract bool doSense(Transform obj,ref Stimulus sti);

    protected virtual void resetSense()
    {

    }
    public void AddSenseHandler(SenseEventHandler handler)
    {
        CallSenseEvent += handler;
    }
    public void AddObjectToTrack(Transform t)
    {
        trackedObjects.Add(t);
    }

    
    public void OnDrawGizmos()
    {
        if (!ShowDebug) { return; }

        Gizmos.color = Color.yellow;
        foreach(Transform t in sensedObjects)
        {
            Gizmos.DrawLine(SenseTransform.position, t.position);
        }
    }
}
