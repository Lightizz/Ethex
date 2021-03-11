using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {
    [SerializeField]
    Player player;

    [SerializeField]
    GameObject settingsContent;

    Resolution[] resolutions;

    public InputField forwardInput;
    public InputField backwardInput;
    public InputField leftInput;
    public InputField rightInput;
    public InputField useInput;
    public InputField jumpInput;
    public InputField dashInput;
    public InputField crouchInput;
    public Slider sensitivitySlider;
    public Toggle mouseInversionToggle;
    public Slider mainvolumeSlider;
    public Dropdown qualityPresetDropdown;
    public Toggle fullScreenToggle;
    public Dropdown resolutionDropdown;


    private void Start() {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> resolutionOptions = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolutions.Length; i++) {
            string resolution = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(resolution);

            if(resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height== Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        SetValuesOfItems();
    }

    void SetValuesOfItems() {
        forwardInput.placeholder.GetComponent<Text>().text = player.forward.ToString();
        backwardInput.placeholder.GetComponent<Text>().text = player.backward.ToString(); 
        leftInput.placeholder.GetComponent<Text>().text = player.left.ToString();
        rightInput.placeholder.GetComponent<Text>().text = player.right.ToString();
        useInput.placeholder.GetComponent<Text>().text = player.use.ToString();
        jumpInput.placeholder.GetComponent<Text>().text = player.jump.ToString();
        crouchInput.placeholder.GetComponent<Text>().text = player.crouch.ToString();
        dashInput.placeholder.GetComponent<Text>().text = player.dash.ToString();
        sensitivitySlider.value = player.mouseSensitivity / 10;
        mouseInversionToggle.isOn = player.isMouseInverted;
        mainvolumeSlider.value = player.mainVolume;
        mainMixer.SetFloat("MainVolume", PlayerPrefs.GetFloat("mainVolume"));
        qualityPresetDropdown.value = player.qualityPresetIndex;
        fullScreenToggle.isOn = player.isFullScreen;
    }

    public void ApplySettings() {
        PlayerPrefs.Save();
    }

    public void ResetSettings() {
        PlayerPrefs.DeleteAll();
        player.LoadPlayerPrefs();
        PlayerPrefs.Save();
    }

    public void SetSensitivty(float mouseSensitivity) {
        player.mouseSensitivity = mouseSensitivity * 10f;
        PlayerPrefs.SetFloat("sensitivity", mouseSensitivity * 10f);
    }

    public void SetMouseInvertion(bool mouseInvertion) {
        player.isMouseInverted = mouseInvertion;
        int i = 0;
        if(mouseInvertion == true) {
            i = 1;
        } else if(mouseInvertion == false) {
            i = 0;
        }
        PlayerPrefs.SetInt("mouseInvert", i);
    }

    public void SetForwardKey(string key) {
        if(key.Split().Length == 1) {
            key = key.ToUpper();
        }
        player.forward = (KeyCode) Enum.Parse(typeof(KeyCode), key);
        PlayerPrefs.SetString("forward", player.forward.ToString());
    }
    public void SetBackwardKey(string key) {
        if(key.Split().Length == 1) {
            key = key.ToUpper();
        }
        player.backward = (KeyCode) Enum.Parse(typeof(KeyCode), key);
        PlayerPrefs.SetString("backward", player.backward.ToString());
    }
    public void SetLeftKey(string key) {
        if(key.Split().Length == 1) {
            key = key.ToUpper();
        }
        player.left = (KeyCode) Enum.Parse(typeof(KeyCode), key);
        PlayerPrefs.SetString("left", player.left.ToString());
    }
    public void SetRightKey(string key) {
        if(key.Split().Length == 1) {
            key = key.ToUpper();
        }
        player.right = (KeyCode) Enum.Parse(typeof(KeyCode), key);
        PlayerPrefs.SetString("right", player.right.ToString());
    }
    public void SetUseKey(string key) {
        if(key.Split().Length == 1) {
            key = key.ToUpper();
        }
        player.use = (KeyCode) Enum.Parse(typeof(KeyCode), key);
        PlayerPrefs.SetString("use", player.use.ToString());
    }
    public void SetJumpKey(string key) {
        if(key.Split().Length == 1) {
            key = key.ToUpper();
        }
        player.jump = (KeyCode) Enum.Parse(typeof(KeyCode), key);
        PlayerPrefs.SetString("jump", player.jump.ToString());
    }
    public void SetCrouchKey(string key) {
        if(key.Split().Length == 1) {
            key = key.ToUpper();
        }
        player.crouch = (KeyCode) Enum.Parse(typeof(KeyCode), key);
        PlayerPrefs.SetString("crouch", player.crouch.ToString());
    }
    public void SetDashKey(string key) {
        if(key.Split().Length == 1) {
            key = key.ToUpper();
        }
        player.dash = (KeyCode) Enum.Parse(typeof(KeyCode), key);
        PlayerPrefs.SetString("dash", player.dash.ToString());
    }

    [SerializeField]
    AudioMixer mainMixer;
    
    public void SetMainVolume(float mainVolume) {
        player.mainVolume = mainVolume;
        PlayerPrefs.SetFloat("mainVolume", mainVolume);
        mainMixer.SetFloat("MainVolume", mainVolume);
    }

    public void SetQualityPreset(int qualityIndex) {
        player.qualityPresetIndex = qualityIndex;
        QualitySettings.SetQualityLevel(qualityIndex);
        PlayerPrefs.SetInt("qualityPresetIndex", qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen) {
        Screen.fullScreen = isFullScreen;
        player.isFullScreen = isFullScreen;
        int i = 0;
        if(isFullScreen == true) {
            i = 1;
        } else if(isFullScreen == false) {
            i = 0;
        }
        PlayerPrefs.SetInt("fullScreen", i);   
    }

    public void SetResolution(int resolutionIndex) {
        Resolution r = resolutions[resolutionIndex];
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);
    }
}
