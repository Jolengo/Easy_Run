using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{

    public Transform Player;
    public Chunk[] ChunkPrefabs;
    public Chunk FirstChunk;

    public float DrowingDistance = 30f;
    public int SpawnedChunkCount = 8;

    private List<Chunk> spawnedChunks = new List<Chunk>();

    private void Start()
    {
        spawnedChunks.Add(FirstChunk);
    }

    private void Update()
    {
        if (Player.position.z > spawnedChunks[spawnedChunks.Count - 1].End.position.z - DrowingDistance)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);

        if (spawnedChunks.Count >= SpawnedChunkCount)
        {
            Destroy(spawnedChunks[0].gameObject);
            spawnedChunks.RemoveAt(0);
        }
    }
    /*
    private Chunk GetRandomChunk()
    {

        List<float> chances = new List<float>();
        for (int i = 0; i < ChunkPrefabs.Length; i++)
        {
            chances.Add(ChunkPrefabs[i].ChanceFromDistance.Evaluate(Player.transform.position.z));
        }

        float value = Random.Range(0, chances.Sum());
        float sum = 0;

        for (int i = 0; i < chances.Count; i++)
        {
            sum += chances[i];
            if (value < sum)
            {
                return ChunkPrefabs[i];
            }
        }

        return ChunkPrefabs[ChunkPrefabs.Length - 1];
    }
    */
}
