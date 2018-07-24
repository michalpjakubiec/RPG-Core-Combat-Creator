using UnityEngine;

[RequireComponent(typeof(CameraRaycaster))]
public class CursorAfforrdance : MonoBehaviour
{
    [SerializeField] Texture2D walkCursor = null;
    [SerializeField] Texture2D targetCursor = null;
    [SerializeField] Texture2D unknownCursor = null;
    [SerializeField] Vector2 cursorHotspot = new Vector2(0, 0);

    CameraRaycaster cameraRaycaster;

    void Start()
    {
        cameraRaycaster = GetComponent<CameraRaycaster>();
        cameraRaycaster.onLayerChange += OnLayerChanged;
    }

    void OnLayerChanged(Layer newLayer)
    {
        print("Cursor over " + cameraRaycaster.currentLayerHit.ToString());

        switch (newLayer)
        {
            case Layer.Walkable:
                Cursor.SetCursor(walkCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.Enemy:
                Cursor.SetCursor(targetCursor, cursorHotspot, CursorMode.Auto);
                break;
            case Layer.RaycastEndStop:
                Cursor.SetCursor(unknownCursor, cursorHotspot, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(unknownCursor, cursorHotspot, CursorMode.Auto);
                Debug.LogError("Don't know what cursor to show");
                break;
        }
    }
}
