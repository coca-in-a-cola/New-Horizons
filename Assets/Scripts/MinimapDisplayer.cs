using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MinimapDisplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject display;
    [SerializeField]
    private string minimapLayer = "Minimap";

    private GameObject spawned = null;

    // Start is called before the first frame update
    void Start()
    {
        OnMinimapSpriteDestroy();
        OnMinimapSpriteDraw();
    }

    public void OnMinimapSpriteDraw()
    {
        spawned = Instantiate(display, transform);
        spawned.name = "Minimap Display";
        // Ensure we have correct minimap layer
        int MinimapLayer = LayerMask.NameToLayer("Minimap");
        spawned.layer = MinimapLayer;
    }

    public void OnMinimapSpriteDestroy()
    {
        if (spawned != null)
            Destroy(spawned);
    }

    public void OnMinimapSpriteDestroyImmediate()
    {
        if (spawned != null)
            DestroyImmediate(spawned);
    }
}
