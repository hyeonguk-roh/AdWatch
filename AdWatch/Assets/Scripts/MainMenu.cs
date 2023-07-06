using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject dialogue;
    public GameObject settings;

    private int clickedSettings = 0;
    private TMP_Text settingsDialogue; 
    private int totalMarks;

    public GameObject dream;
    public GameObject otherSide;
    public GameObject itsName;
    public GameObject submitName;

    public void Start() {
        settingsDialogue = dialogue.GetComponent<TMP_Text>();

        if (PlayerPrefs.HasKey("clickedSettings")) {
            clickedSettings = PlayerPrefs.GetInt("clickedSettings");
        } else {
            PlayerPrefs.SetInt("clickedSettings", clickedSettings);
        }

    }

    public void StartGame() {
        totalMarks = PlayerPrefs.GetInt("Dreaming") + PlayerPrefs.GetInt("OtherSide");

        if (totalMarks == 0) {
            SceneManager.LoadScene("Home");
        }
        if (totalMarks == 1) {
            if (PlayerPrefs.GetInt("Dreaming") == 1) {
                SceneManager.LoadScene("Dreaming");
            }
            else if (PlayerPrefs.GetInt("OtherSide") == 1) {
                SceneManager.LoadScene("OtherSide");
            }
        }
        if (totalMarks > 1) {
            SceneManager.LoadScene("Error");
        }
        
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void Settings() {
        if (clickedSettings == 0) {
            settingsDialogue.text = "I would like to apologize... I got a bit lazy so there are no settings. The settings button does not work. No need to push it again.";
            clickedSettings++;
            
        }
        else if (clickedSettings == 1) {
            settingsDialogue.text = "I think you are a little confused. There are NO settings. This button does not function. Move on. You still got a whole new ad watching experience waiting for you.";
            clickedSettings++;
            
        }
        else if (clickedSettings == 2) {
            settingsDialogue.text = "Come on... this isn't even that intricate of an app. You literally push a button and watch an ad. I really don't think you need settings for this.";
            clickedSettings++;
            
        }
        else if (clickedSettings == 3) {
            settingsDialogue.text = "Ok fine. I'll give you the settings menu. Have fun tinkering with your buttons and sliders. You'll just be wasting your time";
            clickedSettings++;
            PlayerPrefs.SetInt("clickedSettings", clickedSettings);
        }
        else {
            dialogue.SetActive(false);
            settings.SetActive(true);
            if (PlayerPrefs.GetInt("HaveWatched") > 0) {
                dream.SetActive(true);
                otherSide.SetActive(true);
                itsName.SetActive(true);
                submitName.SetActive(true);
            }
        }
    }
}
