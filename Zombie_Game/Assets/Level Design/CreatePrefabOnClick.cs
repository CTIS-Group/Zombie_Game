using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefabOnClick : MonoBehaviour
{

    GameObject TesterClone;
    public GameObject Position;
    public GameObject Tester;

    void Start()
    {
        TesterClone = Instantiate(Tester, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {

        ClickPosition mousePosition = Position.GetComponent<ClickPosition>();
        TesterClone.transform.position = mousePosition.cursorPosition;

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Creator -> " + mousePosition.cursorPosition);

            TesterClone = Instantiate(Tester, mousePosition.cursorPosition, Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }
}
