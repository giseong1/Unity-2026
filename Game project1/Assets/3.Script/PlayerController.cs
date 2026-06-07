    using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        Rigidbody2D rb;
        public float walkForce = 3.0f;
        public float jumpForce = 6.0f;
        float horizon;
        SpriteRenderer spriteRenderer;
        public Sprite idleSprite;
        public Sprite[] walkSprites;
        public Sprite[] jumpSprites;

        public float animationSpeed = 0.1f;
        private float animationTimer = 0f;
        private int spriteIndex = 0;

        public int maxJumpCount = 2;
        private int jumpCount;

        bool wasGrounded;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
        {
            Application.targetFrameRate = 60;
            this.rb = GetComponent<Rigidbody2D>();
            this.spriteRenderer = GetComponent<SpriteRenderer>();

            this.spriteRenderer.sprite = idleSprite;

            jumpCount = maxJumpCount;

    }

    // Update is called once per frame
    void Update()
    {
        // 좌우 이동
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.horizon = -1.0f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            this.horizon = 1.0f;
        }
        else
        {
            this.horizon = 0.0f;
        }
        // 바라보는 방향
        if (horizon > 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizon < 0f)
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount--;
        }

            bool isGrounded = Mathf.Abs(rb.linearVelocity.y) < 0.01f;

        
        if (isGrounded && !wasGrounded)
        {
            jumpCount = maxJumpCount; 
        }

        //애니메이션
        if (Mathf.Abs(rb.linearVelocity.y) > 0.1f)
        {
            animationTimer += Time.deltaTime;

            if (animationTimer >= animationSpeed)
            {
                animationTimer = 0f;

                spriteIndex++;

                if (spriteIndex >= jumpSprites.Length)
                {
                    spriteIndex = 0;
                }
            }

            spriteRenderer.sprite = jumpSprites[spriteIndex];
        }
        // 걷기 애니메이션
        else if (horizon != 0)
        {
            animationTimer += Time.deltaTime;

            if (animationTimer >= animationSpeed)
            {
                animationTimer = 0f;

                spriteIndex++;

                if (spriteIndex >= walkSprites.Length)
                {
                    spriteIndex = 0;
                }

                spriteRenderer.sprite = walkSprites[spriteIndex];
            }
        }
        // Idle
        else
        {
            spriteRenderer.sprite = idleSprite;
            spriteIndex = 0;
            animationTimer = 0f;
        }
    }
        void FixedUpdate()
        {
        
            rb.linearVelocity = new Vector2(horizon * walkForce, rb.linearVelocity.y);
        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 함정(Trap) 태그를 가진 오브젝트와 부딪혔을 때
        if (collision.CompareTag("Trap"))
        {
            GameManager.Instance.LoseLife();
        }
    }
}
