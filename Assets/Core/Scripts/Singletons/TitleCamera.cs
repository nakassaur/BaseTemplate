using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{
    #region Singleton Setup
    public static TitleCamera singleton;

    void Awake()
    {
        singleton = this;
    }
    #endregion    
}
