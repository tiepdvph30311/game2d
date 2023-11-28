using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    public float start, end;
    private bool isFollowing = true;

    void Update()
    {
        if (!isFollowing)
            return;

        var playerX = player.transform.position.x;
        var camX = transform.position.x;
        var camY = transform.position.y;
        var camZ = transform.position.z;

        if (playerX > start && playerX < end)
        {
            camX = playerX;
        }
        else
        {
            if (playerX < start)
            {
                playerX = start;
            }

            if (playerX > end)
            {
                playerX = end;
            }

            // Khi người chơi ra khỏi vùng camera, dừng theo dõi
            isFollowing = false;
        }

        transform.position = new Vector3(camX, camY, camZ);
    }

    // Thêm phương thức để bắt đầu theo dõi lại
    public void StartFollowing()
    {
        isFollowing = true;
    }
}
