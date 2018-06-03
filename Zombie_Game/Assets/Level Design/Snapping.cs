using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapping : MonoBehaviour {

    GameObject TesterClone;
    public GameObject Position;
    public GameObject Tester;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickPosition clickPosition = Position.GetComponent<ClickPosition>();
            TesterClone = Instantiate(Tester, clickPosition.cursorPosition + new Vector3(5f, 0, 0), Quaternion.Euler(0, 0, 0)) as GameObject;

            // Debug.Log("Creator -> " + clickPosition.PositionClick);
        }
    }
}
