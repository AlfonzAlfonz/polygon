using Polygon.Unity.HeightMap;
using UnityEditor;
using UnityEngine;

namespace Polygon.Unity.Editor {
  [CustomEditor (typeof (HeightMapDisplay))]
  [CanEditMultipleObjects]
  public class HeightMapDisplayEditor : UnityEditor.Editor {

    private bool togglePreview = false;
    private Texture2D texture = null;

    public override void OnInspectorGUI () {
      this.DrawDefaultInspector ();

      Preview ();
      var display = (HeightMapDisplay) this.serializedObject.targetObject;
      if (GUILayout.Button ("Apply")) {
        display.ApplyTexture ();
      }
    }

    private void Preview () {
      var display = (HeightMapDisplay) this.serializedObject.targetObject;

      togglePreview = EditorGUILayout.Foldout (togglePreview, "Preview");

      if (togglePreview) {
        EditorGUI.indentLevel++;
        if (texture != null) {
          GUILayout.Box (texture, GUILayout.Width (200), GUILayout.Height (200));
        } else {
          GUILayout.Box ("", GUILayout.Width (200), GUILayout.Height (200));
        }

        if (GUILayout.Button ("Generate")) {
          if (texture == null) {
            texture = new Texture2D (200, 200);
          }
          display.UpdateTexture (texture, 200, 200);
        }
        EditorGUI.indentLevel--;
      }
    }
  }
}