using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    public void ReturnToTitle() {
        SceneManager.LoadScene("Title");
    }
}
