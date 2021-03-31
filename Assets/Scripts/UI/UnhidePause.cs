using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnhidePause : MonoBehaviour
{
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject HiddenUI;
    public void UnhidePauseButton()
    {
        // hide the extra menus
        HiddenUI.SetActive(false);
        // unhide the pause button
        PauseButton.SetActive(true);
    }
}
