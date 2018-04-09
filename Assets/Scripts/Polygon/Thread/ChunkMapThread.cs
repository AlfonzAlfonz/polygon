using System.Collections.Generic;
using System.Threading;
using Polygon.Mesh;
using Polygon.Terrain;
using Polygon.Unity;
using UnityEngine;

namespace Polygon.Thread {
  class ChunkMapThread {

    ChunkGenerator generator;

    IMeshDataMapper mapper;

    System.Threading.Thread thread;

    Queue<Vector3> tasks;

    int grid;

    public Queue<MeshDataChunk> Results { get; private set; }

    public ChunkMapThread (int grid, ChunkGenerator generator, IMeshDataMapper mapper) {
      this.generator = generator;
      this.mapper = mapper;
      this.grid = grid;
      Results = new Queue<MeshDataChunk> ();
      tasks = new Queue<Vector3> ();
      thread = new System.Threading.Thread (ThreadMethod);
    }

    public void Start () {
      thread.Start ();
    }

    public void Stop () {
      thread.Abort ();
    }

    public void RenderChunk (Vector3 position) {
      lock (tasks) {
        tasks.Enqueue (position);
      }
    }

    void ThreadMethod () {
      while (true) {
        if (tasks.Count > 0) {
          Vector3 task;
          lock (tasks) {
            task = tasks.Dequeue ();
          }
          Chunk chunk = generator.CreateChunk (grid, task);
          MeshData data = mapper.GetMeshData (chunk);

          Results.Enqueue (new MeshDataChunk (chunk, data));
        }

        System.Threading.Thread.Sleep (1);
      }
    }
  }
}