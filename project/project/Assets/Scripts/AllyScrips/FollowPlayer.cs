using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    public float moveForce = 20f;   // 加える力の強さ
    public float maxSpeed = 5f;    // 最大速度
    public float minDistance = 2f; // 停止距離
    public float dragAmount = 10f; // 停止時の空気抵抗

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.freezeRotation = true;

        // 物理挙動の安定化
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        // 動きをキビキビさせるために少し抵抗をつける
        rb.drag = 2f;
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector2 direction = (Vector2)target.position - rb.position;
        float distance = direction.magnitude;

        if (distance > minDistance)
        {
            // 1. 停止用の抵抗を通常に戻す
            rb.drag = 2f;

            // 2. 速度が制限を超えていない場合のみ、力を加える
            if (rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(direction.normalized * moveForce);
            }
        }
        else
        {
            // 3. 停止距離内に入ったら、急ブレーキをかける（Dragを上げる）
            // これにより、物理的に自然かつピタッと止まる
            rb.drag = dragAmount;
        }
    }
}
