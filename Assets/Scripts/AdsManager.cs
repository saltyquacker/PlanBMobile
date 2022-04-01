using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour
{
#if UNITY_IOS
    string gameId = "4683178";
#else 
    string gameId = "4683179";
#endif
    // Start is called before the first frame update
    bool testMode = false;
    string placementID = "Banner_Android";

    IEnumerator Start()
    {
        Advertisement.Initialize(gameId,testMode);
        while (!Advertisement.IsReady(placementID))
            yield return null;

        Advertisement.Banner.SetPosition(BannerPosition.TOP_RIGHT);
        Advertisement.Banner.Show(placementID);
    }

    // Update is called once per frame
  
}
