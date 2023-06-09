using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class LayerSwitch : MonoBehaviour
{
    public List<GameObject> Tree_Layers;

    int active_index = -1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            Debug.Log(active_index);
            CycleActive();
            print("space key was pressed");
        }
    }

    //Loops through the list of gameobjects and activates the one at the active index
    void CycleActive()
    {
        if (active_index < Tree_Layers.Count)
        {
            for (int i = 0; i < Tree_Layers.Count; i++)
            {
                if (i == active_index) Tree_Layers[i].SetActive(true);
                else Tree_Layers[i].SetActive(false);
            }
        }
        else
        {
            active_index = 0;

            for (int i = 0; i < Tree_Layers.Count; i++)
            {
                if (i == active_index) Tree_Layers[i].SetActive(true);
                else Tree_Layers[i].SetActive(false);
            }
        }

        active_index++;
    }
}
