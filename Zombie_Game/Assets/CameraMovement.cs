using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    [SerializeField]
    GameObject PlayerToFollow;
    Vector3 CameraStartPoint;
	// Use this for initialization
	void Start () {
        CameraStartPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = CameraStartPoint + PlayerToFollow.transform.position;
	}
}
