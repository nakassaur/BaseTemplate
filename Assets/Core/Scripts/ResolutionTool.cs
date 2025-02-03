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

        public override readonly string ToString()
        {
            return width + "x" + height;
        }
    }

    public static List<ResolutionSimple> GetResolutions()
    {
        List<ResolutionSimple> res = new List<ResolutionSimple>();

        List<Resolution> resolutions = new List<Resolution>();

        resolutions = Screen.resolutions.Reverse().ToList();

        foreach (Resolution r in resolutions)
            res.Add(new ResolutionSimple(r.width, r.height));

        return res.Distinct().ToList();
    }

    public static List<RefreshRate> GetRefreshRates()
    {
        List<Resolution> resolutions = new List<Resolution>();

        resolutions = Screen.resolutions.Reverse().ToList();

        List<RefreshRate> refreshRates = resolutions.Select(x => x.refreshRateRatio).Distinct().ToList();

        return refreshRates;
    }
}
