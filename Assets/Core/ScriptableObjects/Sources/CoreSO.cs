using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "CoreSO", menuName = "ScriptableObjects/CoreSO")]
public class CoreSO : ScriptableObject
{
    [SerializeField] LoadingScreenSO LoadingScreenSO;

    public void LoadScene(int sceneId)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneId);
        LoadingScreenSO.AddAsync(op, SceneManager.GetSceneByBuildIndex(sceneId).name);
    }

    public void ExitToWindows()
    {
        if (Application.isEditor == true) return;

        Application.Quit();
    }
}