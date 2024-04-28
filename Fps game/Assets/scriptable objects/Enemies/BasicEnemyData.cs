using UnityEngine;

[CreateAssetMenu(fileName = "BasicEnemyData", menuName = "ScriptableObjects/BasicEnemyDataScriptableObject", order = 1)]
public class BasicEnemyData : ScriptableObject
{

    [SerializeField] public int speed;
    [SerializeField] public int life;

}
