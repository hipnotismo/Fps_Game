using UnityEngine;

public class BaseGun : MonoBehaviour
{
   public Camera fpsCamera;
   public bool fire;

    void Update()
    {
        fire = Input.GetMouseButtonDown(0);
        Shoot();
    }

    public virtual void Shoot()
    {

    }
}
