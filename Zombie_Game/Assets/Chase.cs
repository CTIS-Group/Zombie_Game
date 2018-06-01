using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour {

    GameObject PlayerToFollow;
    [SerializeField]
    float MovementSpeed = 5f;
    [SerializeField]
    NavMeshAgent agent;

	// Use this for initialization
	void Start ()
    {
        PlayerToFollow = GameObject.FindGameObjectWithTag("Player");	
	}
	
	// Update is called once per frame
	void Update ()
    {
        agent.SetDestination(PlayerToFollow.transform.position);
	}
}
