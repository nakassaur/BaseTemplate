using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomNetworkManager : NetworkManager
{
    [SerializeField] LoadingScreenSO LoadingScreenSO;

    public override void OnAsyncSet(AsyncOperation operation, string sceneName)
    {
        LoadingScreenSO.AddAsync(operation, sceneName);
    }

}