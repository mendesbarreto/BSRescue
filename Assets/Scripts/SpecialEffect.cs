using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SpecialEffect : MonoBehaviour 
{

    public static SpecialEffect instance;

    [SerializeField]
    private ParticleSystem brokeEffect;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Multiple instances of SpecialEffectsHelper!");
        }

        instance = this;
    }


    public void Explosion(Vector2 position)
    {
        instantiate(brokeEffect, position);
    }

    private ParticleSystem instantiate(ParticleSystem prefab, Vector2 position)
    {
        ParticleSystem newParticleSystem = Instantiate(prefab, position, Quaternion.identity) as ParticleSystem;

        Destroy(newParticleSystem.gameObject, newParticleSystem.main.startLifetimeMultiplier);

        return newParticleSystem;
    }
}
