using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public string Name;
    public GameObject BulletFX;
    [Tooltip("Maximum fire in seconds")]
    public float FireRate = 15f;
}
