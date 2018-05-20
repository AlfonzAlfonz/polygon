using System.Collections.Generic;
using Polygon.Mesh;
using Polygon.Unity;
using UnityEngine;

namespace Polygon.Terrain.Model {
  public class Map {
    public Transform player;

    public Dictionary<Vector2, Chunk> Chunks { get; private set; }
    public int Grid { get; set; }

    public int ViewDistance { get; set; }

    public IChunkGenerator Generator { get; set; }

    public GameObjectGenerator GameObjectGenerator { get; set; }

    public Map (int grid, int viewDistance, IChunkGenerator generator, GameObjectGenerator gameObjectGenerator) {
      Chunks = new Dictionary<Vector2, Chunk> ();
      Grid = grid;
      ViewDistance = viewDistance;
      Generator = generator;
      GameObjectGenerator = gameObjectGenerator;
    }

    public void Update () {
      var playerChunk = new Vector2 (Mathf.Floor (player.position.x / Grid), Mathf.Floor (player.position.z / Grid));

      for (int x = -ViewDistance; x < ViewDistance; x++) {
        for (int y = -ViewDistance; y < ViewDistance; y++) {
          var position = new Vector2 (playerChunk.x + x, playerChunk.y + y);

          if (!Chunks.ContainsKey (position)) {
            var chunk = new Chunk (position, Grid);
            chunk.Active = true;
            Generator.CreateChunk (chunk);
            if (chunk.GameObject == null) {
              GameObjectGenerator.CreateGameObject (chunk);
            }
            Chunks.Add (position, chunk);
          } else {
            Chunks[position].Active = true;
          }
        }
      }
    }

  }
}