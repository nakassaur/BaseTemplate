using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

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
            op.completed += Async_Completed;
            _scenesLoading.Add(SceneManager.LoadSceneAsync((int)SceneIndex.UI, LoadSceneMode.Additive));            
        }

        //        
        StartCoroutine(GetLoadProgress(sceneLoaded.buildIndex));
    }
        
    // -- Event Signature
    void LoadingScreenSO_EventOnAsyncAdd(AsyncOperation op, string sceneName) { InternalAddAsync(op, sceneName); }
    
    void Async_Completed(AsyncOperation obj)
    {
        // Deletes the Camera that belongs to the scene structure pre-game (title & main menu)
        // to prevent undesired behaviours
        if (TitleCamera.singleton == null) return;

        if (_debug == true) Debug.LogError("LoadingScreenManager: Destroying TITLE CAMERA");
        Destroy(TitleCamera.singleton.gameObject);
    }

    // -- Coroutine
    public IEnumerator GetLoadProgress(int sceneIndex)
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
