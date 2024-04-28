using System;
using System.Collections;
using UnityEngine;

public class Pistol : BaseGun
{
    [SerializeField] float range;
    [SerializeField] ScopeControl Scope;

    public static event Action test = delegate{};
    public override void Shoot()
    {
        if (fire)
        {
           // test?.Invoke();
            RaycastHit hit;
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

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
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            BasicEnemy enemy = hit.transform.GetComponent<BasicEnemy>();
            if (enemy != null)
            {
                Scope.ActivateScope();
                Debug.Log("Hitting enemy");
            }
            else
            {
                Scope.DeactivateScope();
                Debug.Log("Not hitting enemy");

            }
        }
        else
        {
            Scope.DeactivateScope();
        }
    }

}
