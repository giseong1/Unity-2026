using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 100;

    public Sprite[] sprites;
    public float frameTime = 0.1f;

    private SpriteRenderer sr;
    private int currentFrame;
    private float timer;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameTime)
        {
            timer = 0f;
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