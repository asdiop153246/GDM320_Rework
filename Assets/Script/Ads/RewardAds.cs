using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public Button MyButton;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOsAdUnitId = "Rewarded_iOS";
    string _adUnitId = null;
    bool testmode = true;
    Coroutine runningCoroutine;
    bool stopCoroutine;
    GameObject player;
    public Image health1, health2;
    public Image health3, health4, health5;
    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOsAdUnitId : _androidAdUnitId;

        //Disable the button until the ad is ready to show:
        MyButton.interactable = false;
    }
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        runningCoroutine = StartCoroutine(AdCoroutine());
    }
    IEnumerator AdCoroutine()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Advertisement.Initialized = " + Advertisement.isInitialized);
        if (Advertisement.isInitialized)
        {
            stopCoroutine = true;
        }
    }
    private void Update()
    {
        if (stopCoroutine == true)
        {
            StopCoroutine(runningCoroutine);
            stopCoroutine = false;
            LoadAd();
        }
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            MyButton.onClick.AddListener(ShowAd);
            // Enable the button for users to click:
            MyButton.interactable = true;
        }
    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAd()
    {
        // Disable the button:
        MyButton.interactable = false;
        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.
            player.GetComponent<Coinsscript>().IncreaseCoin(20);
            if (health1.gameObject.activeSelf == false)
            {
                health1.gameObject.SetActive(true);
            }
            else if (health2.gameObject.activeSelf == false)
            {
                health2.gameObject.SetActive(true);
            }
            else if (health3.gameObject.activeSelf == false)
            {
                health3.gameObject.SetActive(true);
            }
            else if (health4.gameObject.activeSelf == false)
            {
                health4.gameObject.SetActive(true);
            }
            else if (health5.gameObject.activeSelf == false)
            {
                health5.gameObject.SetActive(true);
            }


            // Load another ad:
            //Advertisement.Load(_adUnitId, this);
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        MyButton.onClick.RemoveAllListeners();
    }
    
}
