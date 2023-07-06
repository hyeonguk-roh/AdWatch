using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class EarnName : MonoBehaviour
{
    public TMP_InputField keyOne;
    public TMP_InputField keyTwo;

    public TMP_Text itsName;

    public Animator theName;

    public void Submit() {
        if (keyOne.text == PlayerPrefs.GetInt("KeyOne").ToString() && keyTwo.text == PlayerPrefs.GetInt("KeyTwo").ToString()) {
            itsName.text = PlayerPrefs.GetString("Name");
            theName.SetBool("unlocked", true);
            Debug.Log("unlocked");
        }
    }
}
