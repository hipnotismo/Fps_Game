using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] BasicEnemyData data;

    private int tempLife;

    private void Start()
    {
        tempLife = data.life;
    }
    public void TakeDamage()
    {
        if (tempLife > 0)
        {
            tempLife--;
        }
        else
        {
            Destroy(gameObject);

        }
    }
}