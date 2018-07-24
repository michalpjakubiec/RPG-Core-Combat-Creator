using UnityEngine;

public class CameraRaycaster : MonoBehaviour
{
    public Layer[] layerPriorities =
    {
        Layer.Enemy,
        Layer.Walkable
    };

    [SerializeField] float distanceToBackground = 100f;
    Camera viewCamera;

    RaycastHit raycastHit;
    public RaycastHit hit { get { return raycastHit; } }

    Layer layerHit;
    public Layer currentLayerHit { get { return layerHit; } }

    public delegate void OnLayerChange(Layer newLayer); // declare
    public event OnLayerChange onLayerChange;           // instance

    void Start()
    {
        viewCamera = Camera.main;
    }

    void Update()
    {
        foreach (Layer layer in layerPriorities)
        {
            var hit = RaycastForLayer(layer);

            if (hit.HasValue)
            {
                raycastHit = hit.Value;
                if (layerHit != layer)
                {
                    layerHit = layer;
                    onLayerChange(layer);
                }
                layerHit = layer;
                return;
            }
        }

        raycastHit.distance = distanceToBackground;

        if (layerHit != Layer.RaycastEndStop)
        {
            layerHit = Layer.RaycastEndStop;
            onLayerChange(Layer.RaycastEndStop);
        }
    }

    RaycastHit? RaycastForLayer(Layer layer)
    {
        int layerMask = 1 << (int)layer;
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitThatHaveInfoFromRaycast;
        bool hasHit = Physics.Raycast(ray, out hitThatHaveInfoFromRaycast, distanceToBackground, layerMask);

        if (hasHit)
        {
            return hitThatHaveInfoFromRaycast;
        }
        return null;
    }
}