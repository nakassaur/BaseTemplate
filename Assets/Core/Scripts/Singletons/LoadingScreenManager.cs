using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;
using Mirror;
using Unity.VisualScripting;

public class LoadingScreenManager : MonoBehaviour
{
    [SerializeField] bool _debug;
    [SerializeField] LoadingScreenSO LoadingScreenSO;
    [SerializeField] GameObject mainContainer;

    [SerializeField] float _postLoadDelay = 2.0f;

    List<AsyncOperation> _scenesLoading = new List<AsyncOperation>();

    void Start()
    {
        LoadingScreenSO.EventOnAsyncAdd += LoadingScreenSO_EventOnAsyncAdd;
    }

    void OnDestroy()
    {
        LoadingScreenSO.EventOnAsyncAdd -= LoadingScreenSO_EventOnAsyncAdd;
    }

    // -- Private Methods
    void InternalAddAsync(AsyncOperation op, string sceneName)
    {
        if (_debug == true) Debug.LogError("LoadingScreenManager: Enabling Container");
        mainContainer.SetActive(true);

        _scenesLoading.Add(op);
        Scene sceneLoaded = SceneManager.GetSceneByPath(sceneName);

        // -- !! Add Subscenes here ie. UI, Results, etc !!
        // Note: These will be loaded when ONLINE map types are the active scene
        if (sceneLoaded.buildIndex == (int)SceneIndex.ONLINE)
        {
            _scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndex.UI, LoadSceneMode.Additive));
        }

        StartCoroutine(GetLoadProgress());
    }

    // -- Event Signature
    void LoadingScreenSO_EventOnAsyncAdd(AsyncOperation op, string sceneName) { InternalAddAsync(op, sceneName); }

    // -- Coroutine
    public IEnumerator GetLoadProgress()
    {
        for (int i = 0; i < _scenesLoading.Count; i++)
        {
            while (_scenesLoading[i].isDone == false)
                yield return null;
        }

        //ftLightmaps.RefreshFull();

        if (_debug == true) Debug.LogError("LoadingScreenManager: Load Complete. Awaiting Delay");

        LeanTween.delayedCall(_postLoadDelay, () =>
        {
            if (_debug == true) Debug.LogError("LoadingScreenManager: Delay elapsed (" + _postLoadDelay + "s)" );

            if (_debug == true) Debug.LogError("LoadingScreenManager: Disabling Container");
            mainContainer.SetActive(false);
            LoadingScreenSO.LoadComplete();
        });

    }

}
