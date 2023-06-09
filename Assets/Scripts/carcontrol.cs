using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcontrol : MonoBehaviour
{
    // PUBLIC VARS
    public GameObject carAnchors; // These are the anchors that indicate which directions the car needs to move in next
    public Transform carTransform; // Contains the currrent transforms of the car, and the next position it needs to move to. 
    float delta = 0.9f;// Will get to next target in <delta> seconds.

    // PRIVATE VARS
    private int nextId = 1;//The index of the next anchor. 
    private float remainingDelta = 0.0f; // time left between targets.  

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        remainingDelta += Time.deltaTime;
        Transform nextTransform = carAnchors.transform.GetChild(nextId);
        Transform prevTransform = carAnchors.transform.GetChild(nextId - 1);
        carTransform.position = Vector3.Lerp(prevTransform.position, nextTransform.position, remainingDelta / delta);
        carTransform.rotation = Quaternion.Lerp(prevTransform.rotation, nextTransform.rotation, remainingDelta / delta);
        if (remainingDelta > delta)
        {
            nextId++;
            remainingDelta = 0.0f;
            Debug.Log(nextId);

        }
        if (nextId == (carAnchors.transform.childCount - 1))
        {
            nextId = 1;
        }

    }
}

