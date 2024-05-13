using System;
using System.Collections;
using UnityEngine;

public class Pistol : BaseGun
{
    [SerializeField] GunData pistolData;
    [SerializeField] ScopeControl Scope;
    [SerializeField] GameObject SpawnPoint;

    public static event Action<Vector3, Quaternion, Vector3, Vector3, bool, ParticleSystem, ParticleSystem, TrailRenderer> TrailCreation;
    public static event Action<TrailRenderer> TrailActivation;
    public override void Shoot()
    {
        if (fire)
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, pistolData.range))
            {
                TrailActivation(pistolData.trailRender);
                TrailCreation(SpawnPoint.transform.position, Quaternion.identity, hit.point, hit.normal,true, pistolData.firingParticleSystem
                    , pistolData.impactParticleSystem, pistolData.trailRender);

                ITakeDamage isHit = hit.collider.GetComponent<ITakeDamage>();
              
                if (isHit != null)
                {
                    isHit.TakeDamage();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, pistolData.range))
        {
            BasicEnemy enemy = hit.transform.GetComponent<BasicEnemy>();

            if (enemy != null)
            {
                Scope.ActivateScope();
            }
            else
            {
                Scope.DeactivateScope();
            }
        }
        else
        {
            Scope.DeactivateScope();
        }
    }

}
