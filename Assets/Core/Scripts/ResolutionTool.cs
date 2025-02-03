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
        List<ResolutionSimple> simple = new List<ResolutionSimple>();

        List<Resolution> resolutions = new List<Resolution>();

        resolutions = Screen.resolutions.Reverse().ToList();

        foreach (Resolution r in resolutions)
            simple.Add(new ResolutionSimple(r.width, r.height));

        List<string> stringMode = new List<string>();

        foreach (ResolutionSimple r in simple)
            stringMode.Add(r.ToString());

        return stringMode;        
    }

    public static List<RefreshRate> GetRefreshRates()
    {
        List<Resolution> resolutions = new List<Resolution>();

        resolutions = Screen.resolutions.Reverse().ToList();

        List<RefreshRate> refreshRates = resolutions.Select(x => x.refreshRateRatio).Distinct().ToList();

        return refreshRates;
    }

    public static List<string> GetRefreshRatesStringList()
    {
        List<Resolution> resolutions = new List<Resolution>();

        resolutions = Screen.resolutions.Reverse().ToList();

        List<RefreshRate> refreshRates = resolutions.Select(x => x.refreshRateRatio).Distinct().ToList();

        List<string> stringMode = new List<string>();

        foreach (RefreshRate r in refreshRates)
            stringMode.Add(r.ToString());

        return stringMode;
    }
}
