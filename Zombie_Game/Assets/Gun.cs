using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public string Name;
    public GameObject BulletEFX;
    [Tooltip("Maximum fire in seconds")]
    public float FireRate = 15f;
    public int BulletLeft = 10;
}
