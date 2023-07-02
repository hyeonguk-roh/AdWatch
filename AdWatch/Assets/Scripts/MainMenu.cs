using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsDialogue;
    public GameObject FakeSettings;

    private bool unlockedSettings = false;

    public void StartGame() {
        SceneManager.LoadScene("Home");
    }

    public void Settings() {
        if (unlockedSettings == true) {
            FakeSettings.SetActive(true);
        } else {
            SettingsDialogue.SetActive(true);
        }
    }

    public void activateSettings() {
        unlockedSettings = true;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
