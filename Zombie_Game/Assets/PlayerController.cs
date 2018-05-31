using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    GameObject[] Guns;

    [SerializeField]
    GameObject GunPosition;

    [SerializeField]
    float MovementSpeed = 10;
    float xMovementFactor, zMovementFactor,
        Rotation,
        NextFireTime = 0;

    bool[] isGunHad;
    Dictionary<string, int> GunIndex = new Dictionary<string, int>();
    int ActiveGunIndex = 0;
    Gun ActiveGunScript;
    GameObject ActiveGunGameObject;

    // Use this for initialization
    void Start()
    {
        isGunHad = new bool[Guns.Length];
        int i = 0;
        foreach (GameObject gun in Guns)
        {
            GunIndex[gun.GetComponent<Gun>().Name] = i;
            isGunHad[i] = true;
            i++;
        }
        ActivateGun();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchWeapons();
        Move();
        Fire();
    }

    private void ActivateGun()
    {
        if (ActiveGunIndex != -1)
        {
            ActiveGunGameObject = Instantiate(Guns[ActiveGunIndex], GunPosition.transform.position, GunPosition.transform.rotation, this.transform);
            ActiveGunScript = Guns[ActiveGunIndex].GetComponent<Gun>();
        }
    }

    private void SwitchWeapons()
    {
        bool isSwitched = false;
        if (CrossPlatformInputManager.GetAxis("Mouse ScrollWheel") > 0f)
        {
            int i = -1;
            do
            {
                i++;
                ActiveGunIndex = (ActiveGunIndex + 1) % Guns.Length;
            } while (!isGunHad[ActiveGunIndex] && i < Guns.Length);
            isSwitched = true;
        }
        else if (CrossPlatformInputManager.GetAxis("Mouse ScrollWheel") < 0f)
        {
            int i = -1;
            do
            {
                ActiveGunIndex = (ActiveGunIndex - 1) % Guns.Length;
                if (ActiveGunIndex == -1)
                    ActiveGunIndex += Guns.Length;
            } while (!isGunHad[ActiveGunIndex] && i < Guns.Length);
            isSwitched = true;
        }

        if (isSwitched)
        {
            Destroy(ActiveGunGameObject);
            ActivateGun();
        }
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

    private void Fire()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && Time.time >= NextFireTime && ActiveGunScript.BulletLeft > 0)
        {
            NextFireTime = Time.time + 1f / ActiveGunScript.FireRate;
            GameObject BulletToDestroy = Instantiate(ActiveGunScript.BulletEFX,
                ActiveGunGameObject.transform.position,
                this.transform.rotation);
            Destroy(BulletToDestroy, 1f);
            ActiveGunScript.BulletLeft--;
        }
    }
}
