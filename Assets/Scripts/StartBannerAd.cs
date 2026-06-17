using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBannerAd : MonoBehaviour
{
    BannerAd ad;

    private void Start()
    {
        ad = FindObjectOfType<BannerAd>();
        ad.ShowBannerAd();
    }

    private void OnDestroy()
    {
        ad.DestroyBannerAd();
    }

}
