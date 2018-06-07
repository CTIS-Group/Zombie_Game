using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    float MovementSpeed = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RotatePlayer();
        MovePlayer();
    }

    void RotatePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        print(ray.ToString());
        float multiplier = (Camera.main.transform.position.y - 1) / Mathf.Abs(ray.direction.y);
        Vector3 MousePosition = new Vector3(
            Camera.main.transform.position.x + ray.direction.x * multiplier,
            1,
            Camera.main.transform.position.z + ray.direction.z * multiplier);
        float angle = Mathf.Atan2(MousePosition.x - transform.position.x, MousePosition.z - transform.position.z) * 180 / Mathf.PI;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    void MovePlayer()
    {
        float xMovementFactor, zMovementFactor;
        xMovementFactor = CrossPlatformInputManager.GetAxis("Horizontal");
        zMovementFactor = CrossPlatformInputManager.GetAxis("Vertical");
        transform.position += new Vector3(xMovementFactor, 0, zMovementFactor) * MovementSpeed * Time.deltaTime;
    }
}
