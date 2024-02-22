using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    // Multiplies by how much I move my mouse in the X direction
    private float sensitivity = 3f;

    // Variable used later to get my mouse direction on the X and Yaxis
    private float horizontalRotation;
    private float verticalRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Hides our mouse
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Get mouse movement in both directions
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Build up roation based on mouse movement
        horizontalRotation += mouseX * sensitivity;
        verticalRotation += mouseY * sensitivity * -1;

        // Limit the amount of vertical rotation so I don't go through the floor
        verticalRotation = Mathf.Clamp(verticalRotation, -10f, 40f);

        // Apllied rotations
        transform.eulerAngles = new Vector3(verticalRotation, horizontalRotation, transform.eulerAngles.z);
        player.eulerAngles = new Vector3(verticalRotation, player.eulerAngles.y, player.eulerAngles.z);

        // Move the focal point with the player
        transform.position = player.position;
    }
}