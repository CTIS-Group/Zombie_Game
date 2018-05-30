using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    int HitsToDie = 3;

    void OnParticleCollision(GameObject other)
    {
        Destroy(other);
        HitsToDie--;
        if (HitsToDie <= 0)
            Destroy(gameObject);
    }
}
