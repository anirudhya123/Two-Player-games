using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.SceneManagement;

public class Interstitial_Ad : MonoBehaviour
{
    public static Interstitial_Ad instance;
    private InterstitialAd interstitial;
    private BannerView bannder;

    private void Awake()
    {
       
        Time.timeScale = 1;
        if (instance == null)
        {
            MobileAds.Initialize(initStatus => { });
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        // int Count = FindObjectsOfType<Interstitial_Ad>().Length;
        // if (Count > 1)
        // {
        //     gameObject.SetActive(false);
        //     Destroy(gameObject);
        // }
        // else
        // {
        //     DontDestroyOnLoad(this.gameObject);
        // }
    }

    void Start()
    {
        MobileAds.SetiOSAppPauseOnBackground(true);

        RequestInterstitial();
    }


    // Update is called once per frame
    // void Update()
    // {
    //         ExitAppUsingBackButton();
    // }

    // public void ExitAppUsingBackButton()
    // {
    //     if (Application.platform == RuntimePlatform.Android)
    //     {
    //         if (Input.GetKey(KeyCode.Escape))
    //         {
                
    //               Application.Quit();
 
                
    //         }
    //     }
    // }
//Google original App id : ca-app-pub-1067327637500631~3346373554
//interstitial = ca-app-pub-3940256099942544/1033173712
    private void RequestInterstitial()
    {
#if UNITY_ANDROID
    
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";                      //TestID

        // string adUnitId = "ca-app-pub-8315388149211537~8465488118";                     //RealID

#elif UNITY_IPHONE
        
        string adUnitId = "ca-app-pub-1067327637500631/1747189412";
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }
        // Initialize an InterstitialAd.
       this.interstitial = new InterstitialAd(adUnitId);

        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpening;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);

    }
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        
        // MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
        //                     + args.Message);
    }

    public void HandleOnAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpening event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        
       MonoBehaviour.print("HandleAdClosed event received");
      //  SceneManager.LoadScene(0);
        

       // RequestInterstitial();
    }


    public void Show_InterstitialAd()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
           //  RequestInterstitial();
        }
        else
        {
             print("Ad is not loaded");
             RequestInterstitial();
        }
    } 
    

   
}
