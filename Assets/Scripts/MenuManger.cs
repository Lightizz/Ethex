using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManger : MonoBehaviour {
    [SerializeField]
    Player player;
    
    void Start() {
        player.LoadPlayerPrefs();
        player.isPaused = true;
        player.isOnGameplay = false;
        player.isViewBlocked = true;
        player.isMoveBlocked = true;
    }

    public void QuitGame() => Application.Quit();

    public void LoadMap() {
        SceneManager.LoadScene(1);
        //Load checkpoint with PlayerPref ici ou dans les start de la scene Map 
    }
}
