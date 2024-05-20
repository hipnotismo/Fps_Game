using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControler : MonoBehaviour
{
    private static MusicControler instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        else
        {
            Destroy(gameObject);
            return;
        }
    }
}
