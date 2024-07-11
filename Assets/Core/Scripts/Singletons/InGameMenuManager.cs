using UnityEngine;

public class InGameMenuManager : MonoBehaviour
{
    #region Singleton Setup
    public static InGameMenuManager singleton;

    void Awake()
    {
        singleton = this;
    }
    #endregion

    [SerializeField] GameObject _mainContainer;
    public bool IsOpen => _mainContainer.activeSelf;


}
