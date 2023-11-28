using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public float backgroundSpeed = 3f;
    public Transform player; // Tham chiếu đến đối tượng người chơi

    void Update()
    {
        // Di chuyển background theo vị trí của người chơi
        MoveBackgroundWithPlayer();

        // Lặp lại background nếu cần
        RepeatBackground();
    }

    void MoveBackgroundWithPlayer()
    {
        // Lấy vị trí hiện tại của background
        Vector3 backgroundPosition = transform.position;

        // Di chuyển theo chiều x của người chơi
        backgroundPosition.x = player.position.x;

        // Áp dụng vị trí mới cho background
        transform.position = backgroundPosition;
    }

    void RepeatBackground()
    {
        // Lấy kích thước của background
        float backgroundSizeX = GetComponent<SpriteRenderer>().bounds.size.x;

        // Nếu background đi qua một khoảng cách, di chuyển nó về phía trước
        if (transform.position.x < player.position.x - backgroundSizeX)
        {
            transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
        }
    }
}
