using UnityEngine;

public class MiniMapTracker : MonoBehaviour
{
    public Transform player;

    public RectTransform playerDot;

    // Ukuran map dunia
    public float mapWidth = 200f;
    public float mapHeight = 200f;

    // Ukuran UI minimap
    public float minimapWidth = 200f;
    public float minimapHeight = 200f;

    void Update()
    {
        float normalizedX = player.position.x / mapWidth;
        float normalizedZ = player.position.z / mapHeight;

        float mapX = normalizedX * minimapWidth;
        float mapY = normalizedZ * minimapHeight;

        playerDot.anchoredPosition = new Vector2(mapX, mapY);
    }
}