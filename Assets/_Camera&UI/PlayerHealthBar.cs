using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class PlayerHealthBar : MonoBehaviour
{

    RawImage healthGlobeRawImage;
    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        healthGlobeRawImage = GetComponent<RawImage>();
    }

    void Update()
    {
        float yValue = -(player.healthAsPercentage / 2f) - 0.5f;
        healthGlobeRawImage.uvRect = new Rect(0f, yValue, 0.5f, 0.5f);
    }
}
