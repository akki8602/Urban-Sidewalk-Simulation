using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] public Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    private float acceleration = 2;
    private Vector3 newPos = new Vector3();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        newPos = movePositionTransform.position;
        navMeshAgent.acceleration = acceleration;
        navMeshAgent.destination = movePositionTransform.position;
        Debug.Log(navMeshAgent.remainingDistance);
        if (navMeshAgent.remainingDistance <= 1.0f)
        {
            newPos = new Vector3(newPos.x + Random.Range(-10.0f, 10.0f), 0, newPos.z + Random.Range(-10.0f, 10.0f));
            movePositionTransform.SetPositionAndRotation(newPos, movePositionTransform.rotation);
        }
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
}
