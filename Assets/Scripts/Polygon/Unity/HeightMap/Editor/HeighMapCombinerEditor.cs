using System.Linq;
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
        MixerField("Master", display.Master);
        foreach (var pair in display.FunctionOptions) {
          MixerField (pair.function.GetType ().Name, pair.options);
        }
      }
    }

    private void MixerField (string name, HeightMapFunctionOptions options) {
      EditorGUILayout.BeginHorizontal ();
      EditorGUILayout.LabelField (name);

      var value = EditorGUILayout.Slider (options.opacity, 0, 1);
      if (value != options.opacity) {
        EditorUtility.SetDirty (this.serializedObject.targetObject);
      }
      options.opacity = value;

      EditorGUILayout.EndHorizontal ();
    }
  }
}