using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapManager : MonoBehaviour {

    public GameObject Manager;
    public Vector3 objectPosition;

    // Update is called once per frame
    void Update()
    {
        CursorManager mousePosition = Manager.GetComponent<CursorManager>();

        objectPosition.x = Mathf.Floor(mousePosition.cursorPosition.x);
        objectPosition.y = mousePosition.cursorPosition.y;
        objectPosition.z = Mathf.Floor(mousePosition.cursorPosition.z);
        
    }
}
