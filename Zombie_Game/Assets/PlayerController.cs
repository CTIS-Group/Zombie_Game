using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    GameObject BulletStartPoint;
    [Tooltip("Maximum fire in seconds"), SerializeField]
    float FireRate = 15f;
    [SerializeField]
    float MovementSpeed = 10;
    float xMovementFactor, zMovementFactor,
        Rotation,
        NextFireTime = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
    {
        RespondToMovement();
        RespondToFire();
    }

    private void RespondToMovement()
    {
        xMovementFactor = CrossPlatformInputManager.GetAxis("Horizontal");
        zMovementFactor = CrossPlatformInputManager.GetAxis("Vertical");
        transform.position += new Vector3(xMovementFactor, 0, zMovementFactor) * MovementSpeed * Time.deltaTime;
        if (zMovementFactor != 0 || xMovementFactor != 0) //if both are 0, no need for rotation
        {
            //the reason for multiplying zMovementFactor with -1 is the situation where the desired rotation
            //is -90 if zMovementFactor = 1, and xMovementFactor = 0. This happens in all situations.
            Rotation = Mathf.Atan2(zMovementFactor * -1, xMovementFactor) * 180 / Mathf.PI;
            transform.rotation = Quaternion.Euler(0, Rotation, 0);
        }
    }

    private void RespondToFire()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && Time.time >= NextFireTime)
        {
            NextFireTime = Time.time + 1f / FireRate;
            GameObject BulletToDestroy = Instantiate(Bullet, BulletStartPoint.transform.position, BulletStartPoint.transform.rotation);
            Destroy(BulletToDestroy, 1f);
        }
    }
}
