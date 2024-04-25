using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Spawn : MonoBehaviour {
    public Transform SpawnPoint;
    public GameObject Prefab;
    private string[] beatmapData;
    public float[] floatData;

    // Start is called before the first frame update
    void Start() {
        LoadTextFile("beatmap_clean.txt");
        //StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update() {

    }

    void LoadTextFile(string fileName) {
        string filePath = Path.Combine(Application.dataPath, "Beatmaps/Maps", fileName);
        if (File.Exists(filePath)) {
            string content = File.ReadAllText(filePath);
            beatmapData = content.Split('\n');
            floatData = new float[beatmapData.Length];
            for (int i = 0; i < beatmapData.Length; i++) {
                floatData[i] = float.Parse(beatmapData[i]);
            }
            NoteManager.instance.loadNotes(floatData);
        }
    }

    IEnumerator SpawnObjects() {
        //yield return new WaitForSeconds(3.356f);
        float startTime = Conductor.instance.getSongPosition();
        foreach (float spawnTime in floatData) {
            float elapsedTime = (Conductor.instance.getSongPosition() - startTime) * 1000f; // Calculate the elapsed time in milliseconds
            float waitTime = spawnTime - elapsedTime; // Calculate the time to wait before spawning
            yield return new WaitForSeconds(waitTime / 1000f - 11);
            Instantiate(Prefab, SpawnPoint.position, SpawnPoint.rotation);
        }
    }
}
