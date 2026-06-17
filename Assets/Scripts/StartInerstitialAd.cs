using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInerstitialAd : MonoBehaviour
{
    Interstitial_Ad ad;

    private void Start()
    {
        ad = FindObjectOfType<Interstitial_Ad>();
        ad.Show_InterstitialAd();
    }
}
