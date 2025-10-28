using UnityEngine;

public class FloorMove : MonoBehaviour
{
    [SerializeField] private float tiltAmount = 10f;  // 最大傾き角度（度）
    [SerializeField] private float tiltSpeed = 5f;    // 傾く速さ
    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    private void OnCollisionStay(Collision collision)
    {
        // 接触点の平均位置を求める
        Vector3 avgPoint = Vector3.zero;
        foreach (var contact in collision.contacts)
        {
            avgPoint += contact.point;
        }
        avgPoint /= collision.contactCount;

        // ローカル空間に変換
        Vector3 localPoint = transform.InverseTransformPoint(avgPoint);

        // 乗った位置に応じて傾く方向を計算
        float tiltX = -localPoint.z * tiltAmount;
        float tiltZ = localPoint.x * tiltAmount;

        // 回転をスムーズに補間
        Quaternion targetRot = Quaternion.Euler(tiltX, 0, tiltZ);
        transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation * targetRot, Time.deltaTime * tiltSpeed);
    }

    private void OnCollisionExit(Collision collision)
    {
        // 元に戻す
        transform.rotation = Quaternion.Lerp(transform.rotation, originalRotation, Time.deltaTime * tiltSpeed);
    }
}
