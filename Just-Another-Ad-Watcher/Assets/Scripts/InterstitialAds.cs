using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using UnityEngine;
using Random=UnityEngine.Random;

using GoogleMobileAds;
using GoogleMobileAds.Api;

using TMPro;

public class InterstitialAds : MonoBehaviour
{
    private string mazeDirection;
    private string[] mazeDialogue =
    {
        "You enter a hallway", 
        "You enter a hAlLwAy",
        "you enter",
        "DO NOT SET HIM FREE",
    };
    int j = 0;

    public TMP_InputField direction;
    public TMP_Text dialogue;

    public GameObject enterButton;
    public GameObject textField;
    public GameObject door;

    public Animator unlock;
    public TMP_Text keyTwo;
    
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
        });

        if (PlayerPrefs.HasKey("MazeDirection")) {
            mazeDirection = PlayerPrefs.GetString("MazeDirection");
            Debug.Log(mazeDirection);
        } else {
            const string chars = "NESW";
            var result = new StringBuilder(10);
            for (int i = 0; i < 10; i++)
            {
                result.Append(chars[Random.Range(0,4)]);
            }
            mazeDirection = result.ToString();
            PlayerPrefs.SetString("MazeDirection", mazeDirection);
            Debug.Log(mazeDirection);
        }
    }

    void Update() {
        if (j < 2) {
            dialogue.text = mazeDialogue[0];
        }
        else if (j < 4) {
            dialogue.text = mazeDialogue[1];
        }
        else if (j < 6) {
            dialogue.text = mazeDialogue[2];
        }
        else if (j < 10) {
            dialogue.text = mazeDialogue[3];
        }
        else {
            enterButton.SetActive(false);
            textField.SetActive(false);
            door.SetActive(true);
            keyTwo.text = "Your second key is " + PlayerPrefs.GetInt("KeyTwo");
            unlock.SetBool("unlocked", true);

        }
    }

    public void Walk() {
        if (direction.text[0] == PlayerPrefs.GetString("MazeDirection")[j]) {
            j++;
            Debug.Log("Walked Forwards");
        } else {
            j = 0;
            LoadInterstitialAd();
            ShowAd();
        }
    }
    // These ad units are configured to always serve test ads.
    #if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-4964548906296481/4611923883";
    #elif UNITY_IPHONE
    private string _adUnitId = "ca-app-pub-3940256099942544/4411468910";
    #else
    private string _adUnitId = "unused";
    #endif

    private InterstitialAd interstitialAd;

    /// <summary>
    /// Loads the interstitial ad.
    /// </summary>
    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (interstitialAd != null)
        {
                interstitialAd.Destroy();
                interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();
        adRequest.Keywords.Add("unity-admob-sample");

        // send the request to load the ad.
        InterstitialAd.Load(_adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    Debug.LogError("interstitial ad failed to load an ad " +
                                    "with error : " + error);
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                            + ad.GetResponseInfo());

                interstitialAd = ad;
            });
    }

    /// <summary>
    /// Shows the interstitial ad.
    /// </summary>
    public void ShowAd()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }
    }

    private void RegisterEventHandlers(InterstitialAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Interstitial ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Interstitial ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Interstitial ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Interstitial ad full screen content closed.");
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                        "with error : " + error);
        };
    }
}
