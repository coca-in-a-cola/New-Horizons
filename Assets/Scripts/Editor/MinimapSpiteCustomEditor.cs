using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MinimapDisplayer))]
public class MinimapSpiteCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MinimapDisplayer minimapDisplayer = (MinimapDisplayer)target;

        EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Create"))
            {
                minimapDisplayer.OnMinimapSpriteDestroyImmediate();
                minimapDisplayer.OnMinimapSpriteDraw();
            }
            if (GUILayout.Button("Destroy"))
            {
                minimapDisplayer.OnMinimapSpriteDestroyImmediate();
            }
        EditorGUILayout.EndHorizontal();
    }
}
