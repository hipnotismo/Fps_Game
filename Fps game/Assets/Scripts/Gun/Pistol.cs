using System;
using System.Collections;
using UnityEngine;

public class Pistol : BaseGun
{
    [SerializeField] GunData pistolData;
    [SerializeField] ScopeControl Scope;

    public static event Action<Vector3, Quaternion, Vector3, Vector3, bool, ParticleSystem, ParticleSystem, TrailRenderer> TrailCreation;

    public override void Shoot()
    {
        if (fire)
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, pistolData.range))
            {
                Debug.Log(hit.transform.name);

                TrailCreation(fpsCamera.transform.position, Quaternion.identity, hit.point, hit.normal,true, pistolData.firingParticleSystem
                    , pistolData.impactParticleSystem, pistolData.trailRender);
                BasicEnemy enemy = hit.transform.GetComponent<BasicEnemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage();
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
