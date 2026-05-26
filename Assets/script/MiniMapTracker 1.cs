using UnityEngine;

public class MiniMapTracker1 : MonoBehaviour
{
    public Transform player;
    public RectTransform playerDot;

    // Batas map dunia
    public float worldMinX = -100f;
    public float worldMaxX = 100f;

    public float worldMinZ = -100f;
    public float worldMaxZ = 100f;

    // Ukuran minimap UI
    public RectTransform minimapRect;

    void Update()
    {
        // Normalisasi posisi player
        float normalizedX =
            Mathf.InverseLerp(worldMinX, worldMaxX, player.position.x);

        float normalizedZ =
            Mathf.InverseLerp(worldMinZ, worldMaxZ, player.position.z);

        // Konversi ke posisi UI
        float mapX =
            normalizedX * minimapRect.rect.width;

        float mapY =
            normalizedZ * minimapRect.rect.height;

        // Geser agar pusat minimap benar
        mapX -= minimapRect.rect.width / 2;
        mapY -= minimapRect.rect.height / 2;

        playerDot.anchoredPosition =
            new Vector2(mapX, mapY);
    }
}