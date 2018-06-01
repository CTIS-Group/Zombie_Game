using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float MovementSpeed = 10;
    float xMovementFactor, zMovementFactor,
        Rotation;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        xMovementFactor = CrossPlatformInputManager.GetAxis("Horizontal");
        zMovementFactor = CrossPlatformInputManager.GetAxis("Vertical");
        transform.position += new Vector3(xMovementFactor, 0, zMovementFactor) * MovementSpeed * Time.deltaTime;
        if (zMovementFactor != 0 || xMovementFactor != 0) //if both are 0, no need for rotation
        {
            Rotation = Mathf.Atan2(xMovementFactor, zMovementFactor) * 180 / Mathf.PI;
            transform.rotation = Quaternion.Euler(0, Rotation, 0);
        }
    }
}
