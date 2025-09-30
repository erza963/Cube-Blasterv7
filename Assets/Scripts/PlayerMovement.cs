using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float speedIncreaseAmount = 2f; // Amount by which speed increases on upgrade

    void Update()
    {
        MovePlayer();
        ClampPlayerPosition();
    }

    // ✅ Handles player movement based on input
    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Face movement direction if moving
        if (direction != Vector3.zero)
        {
            transform.forward = direction;
        }
    }

    // ✅ Keeps player within the ground bounds (-9 to 9)
    void ClampPlayerPosition()
    {
        float clampedX = Mathf.Clamp(transform.position.x, -9f, 9f);
        float clampedZ = Mathf.Clamp(transform.position.z, -9f, 9f);
        transform.position = new Vector3(clampedX, 0.5f, clampedZ);
    }

    // ✅ Increase player speed (used by upgrade)
    public void IncreaseSpeed()
    {
        moveSpeed += speedIncreaseAmount;
        Debug.Log("Player movement speed increased to: " + moveSpeed);
    }
}
