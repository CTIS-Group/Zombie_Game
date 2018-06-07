using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public Vector3 cursorPosition = -Vector3.one;

    void Update()
    {
            
            Plane plane = new Plane(Vector3.up, 0f); // <--- Can set the offset here!
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float DistanceToPlane;

        //Get Position
            if (plane.Raycast(ray, out DistanceToPlane))
            {
                cursorPosition = ray.GetPoint(DistanceToPlane);
            }

            //Print Location
        if (Input.GetMouseButtonDown(0)){ Debug.Log(cursorPosition);}

        //cursorPosition += new Vector3(5.8f, 0, 0); //offset
    }
}
