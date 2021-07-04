using System.Collections;
using UnityEngine;

public class Manager : MonoBehaviour {
    [SerializeField]
    Player player;

    public Camera playerCamera;

    [SerializeField]
    GameObject sceneLight;

    [SerializeField]
    GameObject tutorialSpotLight;

    //The elements of this item are sorted from fist to last.
    public GameObject[] checkPointsSpawns;

    private void Start() {
        player.LoadPlayerPrefs();
        player.isMoveBlocked = false;
        player.isOnGameplay = true;
        player.isPaused = false;
        player.isViewBlocked = false;

        LoadCheckPoint();
        sceneLight.SetActive(false);
    }

    void LoadCheckPoint() {
        StartCoroutine(LoadCheckpoint(2f));
    }

    IEnumerator LoadCheckpoint(float delayTime) {
        yield return new WaitForSecondsRealtime(delayTime);

        float newX = checkPointsSpawns[player.checkPointIndex].transform.position.x;
        float newY = checkPointsSpawns[player.checkPointIndex].transform.position.y;
        float newZ = checkPointsSpawns[player.checkPointIndex].transform.position.z;
        player.transform.position = new Vector3(newX, newY, newZ);

        yield return new WaitForSecondsRealtime(delayTime);

        if(player.checkPointIndex == 0) {
            float a = 35f;
            playerCamera.transform.eulerAngles = new Vector3(a, 0f, 0f);
            player.gameObject.GetComponent<PlayerAdvancement>().StartTutorial(tutorialSpotLight);
        }
    }
}
 
