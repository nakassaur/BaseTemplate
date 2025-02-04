using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsSO", menuName = "ScriptableObjects/SettingsSO")]
public class SettingsSO : ScriptableObject
{
    public readonly string version = "0.0.8";

    public string defaultValueCache;
        
    public void ValidateVersion(string ver)
    {
        Debug.LogError("Validating Settings Version " + ver + " vs " + version);

        if (ver == version)
            return;

        Debug.LogError("Version Mismatch. Cleaning Prefs");

        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetString(PrefsListBase._VERSION, version);
    }

    //
    public delegate void OnSettingsOpenedDelegate();
    public event OnSettingsOpenedDelegate EventOnSettingsOpen;

    public void Open() { this.EventOnSettingsOpen?.Invoke(); }

    public delegate void OnSettingsClosedDelegate();
    public event OnSettingsClosedDelegate EventOnSettingsClose;

    public void Close() { this.EventOnSettingsClose?.Invoke(); }

    //
    public void SetAlias(string alias) { PlayerPrefs.SetString(PrefsListBase._ALIAS, alias); }

    // -- Property Defaults
    readonly static int _MAXFPS = 500;
    public int MaxFPS => _MAXFPS;

    readonly static int _DEFAULTMAXFPS = 300;
    public int DefaultMaxFPS => _DEFAULTMAXFPS;

    readonly static float _DEFAULTSENSITIVITY = 1.0f;
    public float DefaultSensitivity => _DEFAULTSENSITIVITY;

    readonly static bool _DEFAULTVSYNC = false;
    public bool DefaultVSYNC => _DEFAULTVSYNC;

    readonly static float _DEFAULTMASTERVOLUME = 50;
    public float DefaultMasterVolume => _DEFAULTMASTERVOLUME;

    readonly static float _DEFAULTDEADZONEMIN = 0.125f;
    public float DefaultDeadzoneMin => _DEFAULTDEADZONEMIN;

    readonly static float _DEFAULTDEADZONEMAX = 0.925f;
    public float DefaultDeadzoneMax => _DEFAULTDEADZONEMAX;

    public void StoreValueToCache(string parameter)
    {
        switch (parameter)
        {
            case "MaxFPS":
                defaultValueCache = _DEFAULTMAXFPS.ToString();
                break;
            case "Sensitivity":
                defaultValueCache = _DEFAULTSENSITIVITY.ToString();
                break;
            case "VSync":
                if (_DEFAULTVSYNC == true)
                    defaultValueCache = "On";
                else
                    defaultValueCache = "Off";
                break;
            case "MasterVolume":
                defaultValueCache = _DEFAULTMASTERVOLUME.ToString();
                break;
            case "DeadzoneMin":
                defaultValueCache = _DEFAULTDEADZONEMIN.ToString();
                break;
            case "DeadzoneMax":
                defaultValueCache = _DEFAULTDEADZONEMAX.ToString();
                break;
        }
    }

    //
    public delegate void OnSensitivityChangedDelegate(float value);
    public event OnSensitivityChangedDelegate EventOnSensitivityChanged;

    public void SensitivityChanged(float value) { this.EventOnSensitivityChanged?.Invoke(value); }

    //
    public delegate void OnLocaleChangedDelegate(int id);
    public event OnLocaleChangedDelegate EventOnLocaleChanged;

    public void SetLocale(int id) { this.EventOnLocaleChanged?.Invoke(id); }

    //
    public int desiredResolution;

    public string desiredRefreshRate;

    public int desiredWindowMode;

    public void SetDesiredResolution (int index) { desiredResolution = index; }

    public void SetDesiredRefreshRate (string value) { desiredRefreshRate = value; }

    public void SetDesiredWindowMode(int index) { desiredWindowMode = index; }

    [Header("Defaults")]
    public List<string> windowModes;
}

