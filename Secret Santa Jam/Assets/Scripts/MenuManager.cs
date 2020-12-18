using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject ControlsPanel;
    public GameObject OpenOptionsPanel;
    public Text FullScreenText;
    public GameObject FullScreenBtn;

    public bool HelpIsOpen;

    // Start is called before the first frame update
    void Start()
    {
        if (Screen.fullScreen) FullScreenText.text = "Windowed";
        else FullScreenText.text = "Full Screen";

        if (Application.platform == RuntimePlatform.WebGLPlayer) FullScreenBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11)) FullScreen();
    }

    public void ToggleHelp(bool toggle)
    {
        ControlsPanel.SetActive(toggle);
        OpenOptionsPanel.SetActive(!toggle);
        HelpIsOpen = toggle;
    }

    public void FullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;

        if (Screen.fullScreen) FullScreenText.text = "Windowed";
        else FullScreenText.text = "Full Screen";
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
