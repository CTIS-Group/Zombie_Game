using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {

    [SerializeField]
    GameObject[] PickUps;
    [SerializeField]
    GameObject PickUpFX;
    [SerializeField]
    float Delay = 10f;
    Collider collider;
    GameObject CreatedPickUp,
        CreatedPickUpFX;
	// Use this for initialization
	void Start () {
        collider = GetComponent<Collider>();
        collider.enabled = false;
        InvokeRepeating("SpawnPickUp", 0f, Delay);
	}
	
	void SpawnPickUp()
    {
        if (CreatedPickUp) return;

        int random = Random.Range(0, PickUps.Length);
        float x = Random.Range(-40, 40);
        float z = Random.Range(-40, 40);

        CreatedPickUp = Instantiate(PickUps[random], new Vector3(x, 1, z), Quaternion.identity);
        CreatedPickUpFX = Instantiate(PickUpFX, new Vector3(x, 1, z), Quaternion.identity);
        this.transform.position = new Vector3(x, 1, z);
        collider.enabled = true;

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (CreatedPickUp.CompareTag("Gun"))
            {
                other.GetComponent<PlayerGunHandler>().ObtainGun(
                    CreatedPickUp.GetComponent<Gun>().Name);
                other.GetComponent<PlayerGunHandler>().ObtainBullets(
                    CreatedPickUp.GetComponent<Gun>().Name,
                    10);
            }

            Destroy(CreatedPickUp);
            Destroy(CreatedPickUpFX);
            collider.enabled = false;
        }
    }
}
