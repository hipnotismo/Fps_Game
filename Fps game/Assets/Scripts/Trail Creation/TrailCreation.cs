using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailCreation : MonoBehaviour
{
    private void OnEnable()
    {
        Pistol.TrailActivation += TrailActivation;
        Pistol.TrailCreation += TrailSpawn;
    }

    private void OnDisable()
    {
        Pistol.TrailActivation -= TrailActivation;
        Pistol.TrailCreation -= TrailSpawn;

    }

    public void TrailActivation(TrailRenderer trail)
    {
       // trail.Play();
    }

    public void TrailSpawn(Vector3 BulletSpawnPoint, Quaternion identity, Vector3 Point, Vector3 Normal, bool MadeImpact,
        ParticleSystem firingParticleSystem, ParticleSystem impactParticleSystem, TrailRenderer trailRender)
    {
        TrailRenderer trail = Instantiate(trailRender, BulletSpawnPoint, identity);

        StartCoroutine(SpawnTrail(trail, BulletSpawnPoint, Point, Normal, firingParticleSystem, impactParticleSystem, MadeImpact));
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, Vector3 BulletSpawnPoint, Vector3 HitPoint, Vector3 HitNormal, ParticleSystem firingParticleSystem,
        ParticleSystem impactParticleSystem,
        bool MadeImpact)
    {

        Vector3 startPosition = Trail.transform.position;
        float distance = Vector3.Distance(Trail.transform.position, HitPoint);
        float remainingDistance = distance;

        Instantiate(firingParticleSystem, BulletSpawnPoint, Quaternion.LookRotation(HitNormal));

        while (remainingDistance > 0)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, HitPoint, 1 - (remainingDistance / distance));

            remainingDistance -= 100 * Time.deltaTime;

            yield return null;
        }
        Trail.transform.position = HitPoint;
        if (MadeImpact)
        {
            Instantiate(impactParticleSystem, HitPoint, Quaternion.LookRotation(HitNormal));
        }

        Destroy(Trail.gameObject, Trail.time);
    }
}
