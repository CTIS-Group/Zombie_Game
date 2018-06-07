using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerGunHandler : MonoBehaviour
{

    [SerializeField]
    GameObject[] Guns;

    [SerializeField]
    GameObject GunPosition;

    bool[] isGunHad;
    int[] BulletCount;
    Dictionary<string, int> GunIndex = new Dictionary<string, int>();
    int ActiveGunIndex = 0;
    GameObject ActiveGun;

    float NextFireTime = 0;
    // Use this for initialization
    void Start()
    {
        isGunHad = new bool[Guns.Length];
        BulletCount = new int[Guns.Length];
        int i = 0;
        foreach (GameObject gun in Guns)
        {
            GunIndex[gun.GetComponent<Gun>().Name] = i;
            isGunHad[i] = true;
            BulletCount[i] = 1000;
            i++;
        }
        ActivateGun();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchWeapons();
        Fire();
    }

    private void ActivateGun()
    {
        if (ActiveGunIndex != -1 && isGunHad[ActiveGunIndex])
        {
            ActiveGun = Instantiate(Guns[ActiveGunIndex],
                GunPosition.transform.position,
                GunPosition.transform.rotation,
                this.transform);
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
                i++;
                ActiveGunIndex = (ActiveGunIndex - 1) % Guns.Length;
                if (ActiveGunIndex == -1)
                    ActiveGunIndex += Guns.Length;
            } while (!isGunHad[ActiveGunIndex] && i < Guns.Length);
            isSwitched = true;
        }

        if (isSwitched)
        {
            Destroy(ActiveGun);
            ActivateGun();
        }
    }

    private void Fire()
    {
        if (!ActiveGun) return;
        Gun ActiveGunScript = ActiveGun.GetComponent<Gun>();
        if (CrossPlatformInputManager.GetButton("Fire1")
            && Time.time >= NextFireTime
            && BulletCount[GunIndex[ActiveGunScript.Name]] > 0)
        {
            NextFireTime = Time.time + 1f / ActiveGunScript.FireRate;
            GameObject BulletToDestroy = Instantiate(ActiveGunScript.BulletFX,
                ActiveGun.transform.position,
                this.transform.rotation);
            Destroy(BulletToDestroy, 1f);
            BulletCount[GunIndex[ActiveGunScript.Name]]--;
        }
    }
    public void ObtainBullets(string GunName, int Count)
    {
        BulletCount[GunIndex[GunName]] += Count;
    }
    public void ObtainGun(string GunName)
    {
        if (!isGunHad[GunIndex[GunName]])
        {
            isGunHad[GunIndex[GunName]] = true;
            Destroy(ActiveGun);
            ActiveGunIndex = GunIndex[GunName];
            ActivateGun();
        }

    }
}
