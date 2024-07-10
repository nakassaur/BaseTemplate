using UnityEngine;
public class PrefsList : MonoBehaviour
{
    public static readonly string _VERSION = "version";
    public static readonly string _LASTIP = "lastip";
    public static readonly string _LOCALHOST = "127.0.0.1";
    public static readonly string _ALIAS = "alias";

    public static readonly string _SENSITIVITY = "sensitivity";
    public static readonly string _DEADZONEMIN = "deadzoneMin";
    public static readonly string _DEADZONEMAX = "deadzoneMax";

    //
    public static readonly string _LASTCHARACTER = "lastcharacter";
    public static readonly string _LASTCOLOR = "lastcolor";

    // -- Gameplay Related

    // -- Graphics Related
    public static readonly string _FPSLIMIT = "fpsLimit";
    public static readonly string _DISPLAYMODE = "displayMode";
    public static readonly string _MASTERVOLUME = "masterVolume";
    public static readonly string _VOICEVOLUME = "voiceVolume";
    public static readonly string _EFFECTSVOLUME = "effectsVolume";
    public static readonly string _VSYNC = "vsync";
    public static readonly string _SHOWFPS = "showFPS";
    public static readonly string _FOV = "fov";
    public static readonly string _TEXTUREQUALITY = "textureQuality";
    public static readonly string _SHADOWQUALITY = "shadowQuality";
    public static readonly string _ANTIALIASQUALITY = "antialiasQuality";
    public static readonly string _RENDERSCALE = "renderScale";
    public static readonly string _ANISOTROPY = "anisotropyQuality";

    // -- Server Side Configuration
    public static readonly string _MODE = "mode";
    public static readonly string _MAP = "map";
    public static readonly string _TIMELIMIT = "timeLimit";
}