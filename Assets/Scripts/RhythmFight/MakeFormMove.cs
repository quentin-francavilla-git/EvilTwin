using UnityEngine;

public class MakeFormMove : MonoBehaviour
{
    private float speed;
    private float bpm = 120f;
    private SpawnerManager spawner;
    private Rigidbody2D form_rg;

    void Start()
    {
        GameObject spawnerObject = GameObject.Find("Spawner");

        form_rg = GetComponent<Rigidbody2D>();
        spawner = spawnerObject.GetComponent<SpawnerManager>();
        bpm = spawner.musicBpm;
        speed = bpm / 30f;
    }

    void Update()
    {
        form_rg.velocity = new Vector3(-speed, 0, 0);
    }
}
