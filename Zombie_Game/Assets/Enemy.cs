using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    float Health = 100;
    [SerializeField]
    GameObject CollisionEffect;
    void OnParticleCollision(GameObject other)
    {
        DisplayCollisionEffect(other);
        Destroy(other);

        Health -= other.GetComponent<Bullet>().Damage;
        if (Health <= 0)
            Destroy(gameObject);
    }

    private void DisplayCollisionEffect(GameObject other)
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[1];
        other.GetComponent<ParticleSystem>().GetParticles(particles);
        GameObject Effect = Instantiate(CollisionEffect, particles[0].position, Quaternion.Euler(particles[0].rotation3D));
        Destroy(Effect, 0.1f);
    }
}
