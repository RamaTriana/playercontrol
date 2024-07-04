using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;
    private float spawnLimitXLeft = -22f;
    private float spawnLimitXRight = 7f;
    private float spawnPosY = 30f;
    private float startDelay = 3.0f;
    private float spawnInterval = 2f;
    private int spawnIndexMin = 0;
    private int spawnIndexMax;

    // Mulai dipanggil sebelum pembaruan frame pertama
    void Start()
    {
        spawnIndexMax = ballPrefabs.Length; // Tentukan maksimum indeks spawn
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Memunculkan bola acak secara acak posisi x di atas area bermain
    void SpawnRandomBall()
    {
        // Menghasilkan posisi spawn acak di antara spawnLimitXLeft dan spawnLimitXRight
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // Memilih secara acak indeks bola dari rentang yang tersedia
        int ballIndex = Random.Range(spawnIndexMin, spawnIndexMax);

        // Membuat instance bola di lokasi spawn acak dengan rotasi default
        Instantiate(ballPrefabs[ballIndex], spawnPos, Quaternion.identity);
    }
}
