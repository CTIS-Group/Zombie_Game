using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefabOnClick : MonoBehaviour
{

    GameObject TesterClone;
    public GameObject Manager;
    public GameObject Object;

    void Start()
    {
        TesterClone = Instantiate(Object, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

        SnapManager Position = Manager.GetComponent<SnapManager>();
        TesterClone.transform.position = Position.objectPosition;
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Creator -> " + Position.objectPosition);

            TesterClone = Instantiate(Object, Position.objectPosition, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }
}
