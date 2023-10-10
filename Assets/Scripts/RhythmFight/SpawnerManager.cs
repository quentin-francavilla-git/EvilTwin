using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] Transform spawnerPosition;
    public GameObject[] forms;
    private int formsSize;

    private float beatTime;
    public float musicBpm = 120f;
    private float time = 0f;

    void Awake()
    {
        SpriteRenderer spawnerSprite = GetComponent<SpriteRenderer>();

        spawnerSprite.sprite = FightingEnemy.sprite;
        if (FightingEnemy.isFinalBoss) {
            transform.localScale = new Vector3(-9, 9, 1);
            transform.position = new Vector3(3.92f, 0.62f);
            musicBpm = 140f;
        }

        formsSize = forms.GetLength(0);
        beatTime = 60f / musicBpm;
    }

    private void FixedUpdate() {
        int rand = Random.Range(0,2);
        int rand_forms = Random.Range(0, formsSize);

        time += Time.deltaTime;
        if (time >= beatTime) {
            time = 0;
            Instantiate(forms[rand_forms], spawnerPosition.position, Quaternion.identity);
        }
    }
}
