using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
