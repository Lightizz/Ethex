using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    [SerializeField]
    Player player;

    public void LoadMenu() {
        gameObject.SetActive(false);
        player.isMoveBlocked = false;
        player.isViewBlocked = false;
        player.isPaused = false;
        player.isOnGameplay = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
