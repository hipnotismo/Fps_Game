using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour, ITakeDamage
{
    [SerializeField] BasicEnemyData data;

    private int tempLife;

    private void Start()
    {
        tempLife = data.life;
    }

    public void TakeDamage()
    {
        if (tempLife > 1)
        {
            tempLife--;
            Debug.Log(tempLife);
        }
        else
        {
            Destroy(gameObject);

        }
    }
}
