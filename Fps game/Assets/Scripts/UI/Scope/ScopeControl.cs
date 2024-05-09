using UnityEngine;
using UnityEngine.UI;

public class ScopeControl : MonoBehaviour
{
    [SerializeField] Image ScopeDeactivated;

    public void ActivateScope()
    {
        //Debug.Log("its action time");
        ScopeDeactivated.color = Color.red;
    }

    public void DeactivateScope()
    {
        ScopeDeactivated.color = Color.white;

    }
}
