using UnityEngine;

public class ParallaxStars : MonoBehaviour
{
    [Header("Scroll Speed (set small values like 0.001 - 0.01)")]
    public float scrollSpeedX = 0f;    // set >0 if you want sideways drift
    public float scrollSpeedY = 0.01f; // gentle downward drift

    private Renderer rend;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        offset = rend.material.mainTextureOffset;
    }

    void Update()
    {
        // Update only one axis if you want smoother effect
        offset.x += scrollSpeedX * Time.deltaTime;
        offset.y += scrollSpeedY * Time.deltaTime;

        // Wrap so it doesn't "jump"
        if (offset.x > 1f) offset.x -= 1f;
        if (offset.y > 1f) offset.y -= 1f;

        rend.material.mainTextureOffset = offset;
    }
}

