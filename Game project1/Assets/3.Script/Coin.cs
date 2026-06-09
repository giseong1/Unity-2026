using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 100;

    public Sprite[] sprites;

    private SpriteRenderer sr;
    private int currentFrame;
    private float time;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= 0.1f)
        {
            time = 0f;
            currentFrame = (currentFrame + 1) % sprites.Length;
            sr.sprite = sprites[currentFrame];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }

    }
}