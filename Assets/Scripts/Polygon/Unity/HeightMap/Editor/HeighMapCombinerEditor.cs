using Polygon.Unity.HeightMap;
using Polygon.Unity.HeightMap.Model;
using UnityEditor;
using UnityEngine;

namespace Polygon.Unity.Editor {
  [CustomEditor (typeof (HeightMapCombiner))]
  [CanEditMultipleObjects]
  public class HeightMapCombinerEditor : UnityEditor.Editor {

    private bool toggleMixer = false;
    public override void OnInspectorGUI () {
      this.DrawDefaultInspector ();

      Mixer ();
    }

    private void Mixer () {
      var display = (HeightMapCombiner) this.serializedObject.targetObject;

      toggleMixer = EditorGUILayout.Foldout (toggleMixer, "Mixer");
      if (toggleMixer) {
        foreach (var f in display.functions) {
          if (!display.FunctionOptions.ContainsKey (f)) {
            display.FunctionOptions.Add (f, new HeightMapFunctionOptions ());
          }
          EditorGUILayout.BeginHorizontal ();
          EditorGUILayout.LabelField (f.GetType ().Name.ToString ());

          var value = EditorGUILayout.Slider (display.FunctionOptions[f].opacity, 0, 1);
          if (value != display.FunctionOptions[f].opacity) {
            EditorUtility.SetDirty (this.serializedObject.targetObject);
          }
          display.FunctionOptions[f].opacity = value;

          EditorGUILayout.EndHorizontal ();
        }
      }
    }
  }
}