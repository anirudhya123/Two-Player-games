using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BannerAd : MonoBehaviour
{
    public static BannerAd Instance;
    public void Awake()
    {
        if (Instance != null)
            return;

        Instance = this;

        Initialize();

     //   LoadAd();

    }
    private void Initialize()
    {

        MobileAds.Initialize(initStatus => {
            Dictionary<string, AdapterStatus> map = initStatus.getAdapterStatusMap();
            foreach (KeyValuePair<string, AdapterStatus> keyValuePair in map)
            {
                string className = keyValuePair.Key;
                AdapterStatus status = keyValuePair.Value;
                switch (status.InitializationState)
                {
                    case AdapterState.NotReady:
                        // The adapter initialization did not complete.
                        MonoBehaviour.print("Adapter: " + className + " not ready.");
                        break;
                    case AdapterState.Ready:
                        // The adapter was successfully initialized.
                        MonoBehaviour.print("Adapter: " + className + " is initialized.");
                        break;
                }
            }
        });

        OnInitializedBanner();

    }

    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    // private string BannerIdName = "ca-app-pub-8315388149211537~8465488118";//real ad
    private string BannerIdName = "ca-app-pub-3940256099942544/6300978111";//test ad
#elif UNITY_IPHONE
  private string BannerIdName = "ca-app-pub-1067327637500631/7612640058";
#else
  private string _adUnitId = "unused";
#endif

    public BannerView _bannerView;

    /// <summary>
    /// Creates a 320x50 banner at top of the screen.
    /// </summary>
    public void OnInitializedBanner()
    {
        _bannerView?.Destroy();

        _bannerView = new BannerView(BannerIdName, AdSize.SmartBanner, AdPosition.Bottom);

        _bannerView.OnAdLoaded += HandleOnAdLoaded;
        _bannerView.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        _bannerView.OnAdOpening += HandleOnAdOpened;
        _bannerView.OnAdClosed += HandleOnAdClosed;

        _bannerView.LoadAd(new AdRequest.Builder().Build());
        HidBannerAd();
    }


    /// <summary>
    /// Creates the banner view and loads a banner ad.
    /// </summary>
    public void ShowBannerAd()
    {
        // create an instance of a banner view first.
        _bannerView.Show();
        //Screen.SetResolution(Screen.width, Screen.height, false);
        //   Screen.fullScreenMode = FullScreenMode.
        // Screen.SetResolution(Screen.width, Screen.height / 2, true);
    }


    /// <summary>
    /// Destroys the ad.
    /// </summary>
    public void HidBannerAd()
    {
        // Screen.SetResolution(Screen.width, Screen.height, true);
        _bannerView.Hide();
    }
    public void DestroyBannerAd()
    {
        // Screen.SetResolution(Screen.width, Screen.height, true);
       // debugText.text += "\n" + ":Destroyed Banner:";
        _bannerView.Destroy();
    }
    private void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Handle on loaded baner");
    //    debugText.text += "\n" + GetAdId(sender) + ":loaded:";
    }

    private void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        
        //Debug.Log("cameraoffest");
        LoadAdError loadAdError = args.LoadAdError;

        // Gets the domain from which the error came.
        string domain = loadAdError.GetDomain();

        // Gets the error code. See
        // https://developers.google.com/android/reference/com/google/android/gms/ads/AdRequest
        // and https://developers.google.com/admob/ios/api/reference/Enums/GADErrorCode
        // for a list of possible codes.
        int code = loadAdError.GetCode();

        // Gets an error message.
        // For example "Account not approved yet". See
        // https://support.google.com/admob/answer/9905175 for explanations of
        // common errors.
        string message = loadAdError.GetMessage();

        // Gets the cause of the error, if available.
        AdError underlyingError = loadAdError.GetCause();

        // All of this information is available via the error's toString() method.
        // Debug.Log("Load error string: " + loadAdError.ToString());

        // Get response information, which may include results of mediation requests.
        ResponseInfo responseInfo = loadAdError.GetResponseInfo();
        //  Debug.Log("Response info: " + responseInfo.ToString());

     //   debugText.text += ":Failed:";
        //Connnection.Instace.WatchRewardVedioFailed();
    }

    private void HandleOnAdOpened(object sender, EventArgs args)
    {

       // debugText.text += "\n" + GetAdId(sender) + ":Opened:";
    }

    private void HandleOnAdClosed(object semder, EventArgs args)
    {

        DestroyAndInitialize(semder);
      //  debugText.text += ":Closed:";
    }
    private void DestroyAndInitialize(object sender)
    {
        if (sender.Equals(_bannerView))
        {

            //debugText.text += ":Ban Id:";
            _bannerView.Destroy();
            OnInitializedBanner();
        }
   
    }
}