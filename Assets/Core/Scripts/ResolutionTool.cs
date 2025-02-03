using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResolutionTool : MonoBehaviour
{
    public struct ResolutionSimple
    {
        public int width;
        public int height;        

        public ResolutionSimple(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public ResolutionSimple(Resolution resolution)
        {
            this.width = resolution.width;
            this.height = resolution.height;
        }

        public override readonly string ToString()
        {
            return width + "x" + height;
        }
    }

    public static List<ResolutionSimple> GetResolutions()
    {
        List<ResolutionSimple> simple = new List<ResolutionSimple>();

        List<Resolution> resolutions = new List<Resolution>();

        resolutions = Screen.resolutions.Reverse().ToList();

        foreach (Resolution r in resolutions)
            simple.Add(new ResolutionSimple(r.width, r.height));
               
        return simple.Distinct().ToList();
    }

    public static List<string> GetResolutionsStringList()
    {
        List<ResolutionSimple> simple = GetResolutions();

        return simple.Select(x => x.ToString()).ToList();
    }


    // Example
    // Switch to 640 x 480 full-screen at 60 hz
    // Screen.SetResolution(640, 480, FullScreenMode.ExclusiveFullScreen, new RefreshRate() { numerator = 60, denominator = 1 });
    public static List<string> GetRefreshRates()
    {
        List<Resolution> resolutions = new List<Resolution>();

        resolutions = Screen.resolutions.Reverse().ToList();

        List<int> refreshRatesRaw = resolutions.Select(x => Mathf.RoundToInt((float) x.refreshRateRatio.value)).Distinct().ToList();

        refreshRatesRaw.Sort();

        List<string> refreshRates = refreshRatesRaw.Select(x => x.ToString()).Reverse().ToList();

        return refreshRates;
    }

}
