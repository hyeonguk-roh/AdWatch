using System.Collections;
using System.Collections.Generic;
using System.Text;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TheTest : MonoBehaviour
{
    //Menu Items
    public Slider volume;
    public Slider sensitivity;
    public Toggle vSync;
    public Toggle notification;
    public Toggle dreaming;
    public Toggle otherSide;
    public TMP_InputField itsName;

    //MenuItems bool to int
    private int vSyncInt;
    private int notificationInt;
    private int dreamingInt;
    private int otherSideInt;

    //Random Keys
    private int keyOne;
    private int keyTwo;
    private string theName;

    //Animation
    public Animator animator;

    //Unlock other menu options
    private int haveWatched = 0;

    public void Start() {
        //Volume
        if (PlayerPrefs.HasKey("Volume")) {
            volume.value = PlayerPrefs.GetFloat("Volume");
        } else {
            volume.value = 0;
            PlayerPrefs.SetFloat("Volume", volume.value);
        }

        //Sensitivity
        if (PlayerPrefs.HasKey("Sensitivity")) {
            sensitivity.value = PlayerPrefs.GetFloat("Sensitivity");
        } else {
            sensitivity.value = 0;
            PlayerPrefs.SetFloat("Sensitivity", sensitivity.value);
        }

        //VSync
        if (PlayerPrefs.HasKey("VSync")) {
            vSyncInt = PlayerPrefs.GetInt("VSync");
            vSync.isOn = IntToBool(vSyncInt);
        } else {
            vSync.isOn = false;
            vSyncInt = BoolToInt(vSync.isOn);
            PlayerPrefs.SetInt("VSync", vSyncInt);
        }

        //Notification
        if (PlayerPrefs.HasKey("Notification")) {
            notificationInt = PlayerPrefs.GetInt("Notification");
            notification.isOn = IntToBool(notificationInt);
        } else {
            notification.isOn = false;
            notificationInt = BoolToInt(notification.isOn);
            PlayerPrefs.SetInt("Notification", notificationInt);
        }

        //Dreaming
        if (PlayerPrefs.HasKey("Dreaming")) {
            dreamingInt = PlayerPrefs.GetInt("Dreaming");
            dreaming.isOn = IntToBool(dreamingInt);
        } else {
            dreaming.isOn = false;
            dreamingInt = BoolToInt(dreaming.isOn);
            PlayerPrefs.SetInt("Dreaming", dreamingInt);
        }

        //OtherSide
        if (PlayerPrefs.HasKey("OtherSide")) {
            otherSideInt = PlayerPrefs.GetInt("OtherSide");
            otherSide.isOn = IntToBool(otherSideInt);
        } else {
            otherSide.isOn = false;
            otherSideInt = BoolToInt(otherSide.isOn);
            PlayerPrefs.SetInt("OtherSide", otherSideInt);
        }

        //Random Key Generators
        if (PlayerPrefs.HasKey("KeyOne")) {
            keyOne = PlayerPrefs.GetInt("KeyOne");
            Debug.Log(keyOne);
        } else {
            keyOne = Random.Range(0,10);
            PlayerPrefs.SetInt("KeyOne", keyOne);
            Debug.Log(keyOne);
        }

        if (PlayerPrefs.HasKey("KeyTwo")) {
            keyTwo = PlayerPrefs.GetInt("KeyTwo");
            Debug.Log(keyTwo);
        } else {
            keyTwo = Random.Range(0,10);
            PlayerPrefs.SetInt("KeyTwo", keyTwo);
            Debug.Log(keyTwo);
        }

        if (PlayerPrefs.HasKey("Name")) {
            theName = PlayerPrefs.GetString("Name");
            Debug.Log(theName);
        } else {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var result = new StringBuilder(10);
            for (int i = 0; i < 10; i++)
            {
                result.Append(chars[Random.Range(0,26)]);
            }
            theName = result.ToString();
            PlayerPrefs.SetString("Name", theName);
            Debug.Log(theName);
        }
    }

    public void Update() {
        //Volume
        PlayerPrefs.SetFloat("Volume", volume.value);

        //Sensitivity
        PlayerPrefs.SetFloat("Sensitivity", sensitivity.value);

        //VSync
        vSyncInt = BoolToInt(vSync.isOn);
        PlayerPrefs.SetInt("VSync", vSyncInt);

        //Notification
        notificationInt = BoolToInt(notification.isOn);
        PlayerPrefs.SetInt("Notification", notificationInt);

        //Dreaming
        dreamingInt = BoolToInt(dreaming.isOn);
        PlayerPrefs.SetInt("Dreaming", dreamingInt);

        //OtherSide
        otherSideInt = BoolToInt(otherSide.isOn);
        PlayerPrefs.SetInt("OtherSide", otherSideInt);
    }

    private int BoolToInt(bool val) {
        if (val) return 1;
        else return 0;
    }

    private bool IntToBool(int val) {
        if (val == 0) return false;
        else return true;
    }

    public void SubmitTest() {
        if (itsName.text == theName) {
            animator.SetBool("OpenedDoor", true);
            Debug.Log("Opened Door!!");
        }
    }

    public void EnterTheDoor(){
        SceneManager.LoadScene("ItIsHere");
    }
}
