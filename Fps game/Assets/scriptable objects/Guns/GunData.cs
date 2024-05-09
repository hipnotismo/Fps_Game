using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasicGunData", menuName = "ScriptableObjects/BasicGunDataScriptableObject", order = 1)]

public class GunData : ScriptableObject
{
    public ParticleSystem firingParticleSystem;
    public ParticleSystem impactParticleSystem;
    public TrailRenderer trailRender;

    public float range;
    public float speed;
}
