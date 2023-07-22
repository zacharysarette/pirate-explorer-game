using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;

    public GameObject player_sprite;

   private Vector2 lastDirection = Vector2.up; // Default starting direction (facing up)

    void Update()
    {
        // Get horizontal and vertical input values
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput);

        // Normalize the movement vector to handle diagonal movement at the same speed
        movement = movement.normalized;

        // Rotate the player's body
        if (movement != Vector2.zero)
        {
            lastDirection = movement;
            float angle = Mathf.Atan2(movement.x, -movement.y) * Mathf.Rad2Deg;
            player_sprite.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

        // Move the player
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}