using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestoy : MonoBehaviour
{
    private void Awake()
    {
        if (this != null)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}
