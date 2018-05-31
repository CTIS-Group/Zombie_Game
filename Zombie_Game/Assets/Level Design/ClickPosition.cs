using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPosition : MonoBehaviour
{

    public GameObject Tester;
    GameObject TesterClone;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 PositionClick = -Vector3.one;

            Plane plane = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float DistanceToPlane;

            if (plane.Raycast(ray, out DistanceToPlane))
            {
                PositionClick = ray.GetPoint(DistanceToPlane);
            }

            Debug.Log(PositionClick);

            TesterClone = Instantiate(Tester, PositionClick+new Vector3(5f,0,0), Quaternion.Euler(0, 0, 0)) as GameObject;
        }
    }
}
