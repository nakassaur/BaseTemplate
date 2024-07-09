using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LoadingScreenSO", menuName = "ScriptableObjects/LoadingScreen SO")]
public class LoadingScreenSO : ScriptableObject
{
    public delegate void OnAsyncAddDelegate(AsyncOperation op, string sceneName);
    public event OnAsyncAddDelegate EventOnAsyncAdd;

    public void AddAsync(AsyncOperation op, string sceneName) { this.EventOnAsyncAdd?.Invoke(op, sceneName); }

    //
    public delegate void OnLoadCompleteDelegate();
    public event OnLoadCompleteDelegate EventOnLoadComplete;

    public void LoadComplete() {  this.EventOnLoadComplete?.Invoke(); }
    
}
