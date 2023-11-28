using UnityEngine;
using UnityEngine.UI;

public class tuontac : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 10f;
    public Text scoreText;
    public GameObject panel;
    public Text panelText;
    public float cameraFollowSpeed = 5f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private int score = 0;
    private bool isPanelActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        UpdateScoreText();
        panel.SetActive(false);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        Camera.main.transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tien"))
        {
            Destroy(other.gameObject);
            score++;
            UpdateScoreText();
        }
        else if (other.CompareTag("Vuc") && !isPanelActive)
        {
            panel.SetActive(true);
            panelText.gameObject.SetActive(true);
            ShowPanel("Bạn đã rơi xuống hố!");
            isPanelActive = true;

            // Gọi phương thức để bắt đầu theo dõi lại camera
            FindObjectOfType<camera>().StartFollowing();
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void RestartGame()
    {
        score = 0;
        UpdateScoreText();
        transform.position = Vector3.zero;
        panel.SetActive(false);
        isPanelActive = false;
    }

    void ShowPanel(string message)
    {
        panelText.text = message;
    }
}
