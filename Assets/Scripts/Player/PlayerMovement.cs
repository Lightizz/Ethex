using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {
    [SerializeField]
    Player player;

    [SerializeField]
    CharacterController controller;

    [SerializeField]
    Transform groundCheckTransform;
    [SerializeField]
    float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float gravity = Physics.gravity.y * 2;
    Vector3 velocity;

    void Update() {
        if(player.isMoveBlocked) {
            return;
        }
        float x = 0f;
        float z = 0f;

        player.isOnGround = Physics.CheckSphere(groundCheckTransform.position, groundDistance, groundMask);

        if(player.isOnGround && velocity.y < 0) {
            velocity.y = -2f;
        }

        if(Input.GetKey(player.left) && Input.GetKey(player.right)) {
            x = 0;
        }else if(Input.GetKey(player.left)) {
            x = -1;
        } else if(Input.GetKey(player.right)) {
            x = 1;
        }

        if(Input.GetKey(player.forward) && Input.GetKey(player.backward)) {
            z = 0;
        }else if(Input.GetKey(player.forward)) {
            z = 1;
        } else if(Input.GetKey(player.backward)) {
            z = -1;
        }

        if(z != 0 || x != 0) {
            player.isMoving = true;
        } else if(z == 0 && x == 0) {
            player.isMoving = false;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * player.speed * Time.deltaTime);

        if(Input.GetKeyDown(player.jump) && player.isOnGround) {
            velocity.y = Mathf.Sqrt(player.jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
