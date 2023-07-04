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

    public void Start() {
        settingsDialogue = dialogue.GetComponent<TMP_Text>();
    }

    public void StartGame() {
        SceneManager.LoadScene("Home");
    }

    public void ReturnToTitle() {
        SceneManager.LoadScene("Title");
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
            settingsDialogue.text = "Come on... this isn't even that intricate of an app. You literally push a button and watch an ad. I realy don't think you need settings for this.";
            clickedSettings++;
        }
        else if (clickedSettings == 3) {
            settingsDialogue.text = "Ok fine. I'll give you the settings menu. Have fun tinkering with your buttons and sliders. You'll just be wasting your time";
            clickedSettings++;
        }
        else {
            dialogue.SetActive(false);
            settings.SetActive(true);
        }
    }
}
