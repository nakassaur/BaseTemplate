using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour
{
    [SerializeField] bool _debug;
    [SerializeField] float postLoadDelay = 2.0f;

    // Notes: Technically this is a LoadingScreen. However do not confuse this with the traditional
    // loading screen which will be called using the NetworkManager.
    
    // This one is specific to the Intro Process and does not share the same design with the traditional one.
    // This specific loading screen will be referred as WAIT SCREEN and represents the Main Menu Loading Screen;

    List<AsyncOperation> _scenesLoading = new List<AsyncOperation>();
            
    public void IntroComplete()
    {
        _scenesLoading.Add(SceneManager.LoadSceneAsync((int) SceneIndex.OFFLINE, LoadSceneMode.Additive));
        _scenesLoading.Add(SceneManager.LoadSceneAsync((int) SceneIndex.SETTINGS, LoadSceneMode.Additive));

        StartCoroutine(nameof(GetLoadProgress));                
    }

    public IEnumerator GetLoadProgress()
    {
        for (int i = 0; i < _scenesLoading.Count; i++)
        {
            while (_scenesLoading[i].isDone == false)
                yield return null;
        }

        if (_debug == true) Debug.LogError("StartupManager: Load Complete");

        // Load Complete
        LeanTween.delayedCall(postLoadDelay, () =>
        {
            if (_debug == true) Debug.LogError("StartupManager: Delay Elapsed. Switching ActiveScene");
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex((int)SceneIndex.OFFLINE));

            if (_debug == true) Debug.LogError("StartupManager: Unloading TITLE");
            SceneManager.UnloadSceneAsync((int)SceneIndex.TITLE);            
        });        
    }
}
