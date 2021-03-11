using System.Collections;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    [SerializeField]
    Player player;

    [SerializeField]
    Transform playerBody;

    float xRotation = 0f;

    void Update() {
        if(player.isViewBlocked == true) {
            return;
        }

        float mouseX = Input.GetAxis("Mouse X") * player.mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * player.mouseSensitivity * Time.deltaTime;

        if(player.isMouseInverted) {
            xRotation += mouseY;
            mouseX = -mouseX;
        } else {
            xRotation -= mouseY;
        }

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
