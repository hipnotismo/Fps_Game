using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class BasicShooting : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] Camera fpsCamera;
    private bool fire;

    private void Start()
    {
    }
    void Update()
    {
        fire = Input.GetMouseButtonDown(0);
        Shoot();
    }

    void Shoot()
    {
        if (fire)
        {
            RaycastHit hit;
            if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
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
}
