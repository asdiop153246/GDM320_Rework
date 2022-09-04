using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class Bannerads : MonoBehaviour
{
    // For the purpose of this example, these buttons are for functionality testing:
    

    [SerializeField] BannerPosition _bannerPosition = BannerPosition.BOTTOM_CENTER;

    [SerializeField] string _androidAdUnitId = "Banner_Android";
    [SerializeField] string _iOsAdUnitId = "Banner_iOS";
    string _adUnitId;
    GameObject player;
    void Start()
    {
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOsAdUnitId : _androidAdUnitId;

        // Disable the button until an ad is ready to show:


        // Set the banner position:
        Advertisement.Banner.SetPosition(_bannerPosition);
        player = GameObject.FindWithTag("Player");
        // Configure the Load Banner button to call the LoadBanner() method when clicked:
        LoadBanner();
    }

    // Implement a method to call when the Load Banner button is clicked:
    public void LoadBanner()
    {
        // Set up options to notify the SDK of load events:
        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = OnBannerLoaded,
            errorCallback = OnBannerError
        };

        // Load the Ad Unit with banner content:
        Advertisement.Banner.Load(_adUnitId, options);
    }

    // Implement code to execute when the loadCallback event triggers:
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        ShowBannerAd();

        // Configure the Show Banner button to call the ShowBannerAd() method when clicked:
        
        // Configure the Hide Banner button to call the HideBannerAd() method when clicked:
        

        // Enable both buttons:
        
    }

    // Implement code to execute when the load errorCallback event triggers:
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
        // Optionally execute additional code, such as attempting to load another ad.
    }

    // Implement a method to call when the Show Banner button is clicked:
    void ShowBannerAd()
    {
        // Set up options to notify the SDK of show events:
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        // Show the loaded Banner Ad Unit:
        Advertisement.Banner.Show(_adUnitId, options);
    }

    // Implement a method to call when the Hide Banner button is clicked:
    void HideBannerAd()
    {
        // Hide the banner:
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() 
    {
        HideBannerAd();
        player.GetComponent<Coinsscript>().IncreaseCoin(10);
        
    }
    void OnBannerShown() { }
    void OnBannerHidden() { }

    void OnDestroy()
    {
        // Clean up the listeners:
        
    }
}
