using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    [SerializeField]
    GameObject pauseUI;

    //Var to save
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode dash;
    public KeyCode crouch;
    public KeyCode use;
    public float mouseSensitivity;
    public bool isMouseInverted;
    public int checkPointIndex;
    public float mainVolume;
    public int qualityPresetIndex;
    public bool isFullScreen;

    public bool isViewBlocked = false;
    public bool isMoveBlocked = false;
    public bool isOnGameplay = true;
    public bool isPaused = false;
    public bool isOnGround = true;
    public bool isMoving = false;
    public float speed = 5f;
    public float jumpHeight = 2.5f;

    private void Start() {
        LoadPlayerPrefs();
    }

    void OnApplicationQuit() {
        SaveGame();
        PlayerPrefs.Save();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex == 1) {
            if(isPaused == false && isOnGameplay == true) {
                Pause();
            }
            else if(isPaused == true && isOnGameplay == false) {
                UnPause();
            }
        }

        if(isOnGameplay == true || isPaused == false) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        } else if(isOnGameplay == false || isPaused == true) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true; 
        }
    }

    public void Pause() {
        isMoveBlocked = true;
        isViewBlocked = true;
        isPaused = true;
        isOnGameplay = false;
        Time.timeScale = 0f;
        if(isMoving == true) {
            isMoving = false;
        }
        pauseUI.SetActive(true);
    }

    public void UnPause() {
        pauseUI.SetActive(false);
        isMoveBlocked = false;
        isViewBlocked = false;
        isPaused = false;
        isOnGameplay = true;
        Time.timeScale = 1f;
    }

    public void SetDefaultValues() {
        forward = KeyCode.Z;
        backward = KeyCode.S;
        left = KeyCode.Q;
        right = KeyCode.D;
        jump = KeyCode.Space;
        use = KeyCode.F;
        dash = KeyCode.LeftAlt;
        crouch = KeyCode.LeftControl;
        isMouseInverted = false;
        mouseSensitivity = 150f;
        mainVolume = 0f;
        qualityPresetIndex = 2;
        isFullScreen = false;

        PlayerPrefs.Save();
    }

    public void NewGame() {
        checkPointIndex = 0;
        PlayerPrefs.DeleteKey("checkpoint");
        PlayerPrefs.SetInt("checkpoint", checkPointIndex);
        PlayerPrefs.Save();
    }

    public void SaveGame() {
        PlayerPrefs.SetInt("checkpoint", checkPointIndex);
        PlayerPrefs.Save();
    }

    public void LoadPlayerPrefs() {
        SetDefaultValues();
        if(!PlayerPrefs.HasKey("forward")) {
            PlayerPrefs.SetString("forward", forward.ToString());
        } else {
            forward = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forward"));
        }

        if(!PlayerPrefs.HasKey("backward")) {
            PlayerPrefs.SetString("backward", backward.ToString());
        } else {
            backward = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backward"));
        }

        if(!PlayerPrefs.HasKey("left")) {
            PlayerPrefs.SetString("left", left.ToString());
        } else {
            left = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("left"));
        }

        if(!PlayerPrefs.HasKey("right")) {
            PlayerPrefs.SetString("right", right.ToString());
        } else {
            right = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("right"));
        }

        if(!PlayerPrefs.HasKey("use")) {
            PlayerPrefs.SetString("use", use.ToString());
        } else {
            use = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("use"));
        }

        if(!PlayerPrefs.HasKey("jump")) {
            PlayerPrefs.SetString("jump", jump.ToString());
        } else {
            jump = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jump"));
        }

        if(!PlayerPrefs.HasKey("crouch")) {
            PlayerPrefs.SetString("crouch", crouch.ToString());
        } else {
            crouch = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("crouch"));
        }

        if(!PlayerPrefs.HasKey("dash")) {
            PlayerPrefs.SetString("dash", dash.ToString());
        } else {
            dash = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("dash"));
        }

        int i = 0;
        if(!PlayerPrefs.HasKey("mouseInvert")) {
            PlayerPrefs.SetInt("mouseInvert", i);
        } else {
            i = PlayerPrefs.GetInt("mouseInvert");
        }
        if(i == 1) {
            isMouseInverted = true;
        } else if(i == 0){
            isMouseInverted = false;
        }

        if(!PlayerPrefs.HasKey("sensitivity")) {
            PlayerPrefs.SetFloat("sensitivity", mouseSensitivity);
        } else {
            mouseSensitivity = PlayerPrefs.GetFloat("sensitivity");
        }

        if(!PlayerPrefs.HasKey("mainVolume")) {
            PlayerPrefs.SetFloat("mainVolume", mainVolume);
        } else {
            mainVolume = PlayerPrefs.GetFloat("mainVolume");
        }

        if(!PlayerPrefs.HasKey("qualityPresetIndex")) {
            PlayerPrefs.SetInt("qualityPresetIndex", qualityPresetIndex);
        } else {
            qualityPresetIndex = PlayerPrefs.GetInt("qualityPresetIndex");
        }

        int a = 0;
        if(!PlayerPrefs.HasKey("fullScreen")) {
            PlayerPrefs.SetInt("fullScreen", a);
        } else {
            a = PlayerPrefs.GetInt("fullScreen");
        }
        if(a == 1) {
            isFullScreen = true;
        } else if(a == 0) {
            isFullScreen = false;
        }

        PlayerPrefs.Save();
    }
}
