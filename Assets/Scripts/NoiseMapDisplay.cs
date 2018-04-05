using System.Collections;
using System.Collections.Generic;
using Polygon.Noise;
using UnityEngine;

public class NoiseMapDisplay : MonoBehaviour {

	public int width;
	public int height;

	public Vector2 offset;
	
	public List<Octave> octaves;

	void Update () {
		var meshR = GetComponent<MeshRenderer> ();

		var texture = new Texture2D (width, height);
		texture.filterMode = FilterMode.Point;
		texture.wrapMode = TextureWrapMode.Clamp;
		texture.SetPixels (NoiseMapToTexture (Noise.PerlinNoise (width, height, offset, octaves.ToArray())));
		texture.Apply ();

		meshR.sharedMaterial.mainTexture = texture;
	}

	private Color[] NoiseMapToTexture (float[, ] map) {
		var colors = new Color[map.GetLength (0) * map.GetLength (1)];

		for (int x = 0; x < map.GetLength (0); x++) {
			for (int y = 0; y < map.GetLength (1); y++) {
				colors[x * map.GetLength (1) + y] = Color.Lerp (Color.black, Color.white, map[x, y]);
			}
		}

		return colors;
	}
}