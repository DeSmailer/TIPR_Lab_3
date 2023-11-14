using UnityEngine;

public class RotateBySelf : MonoBehaviour
{
    [SerializeField] private Vector3 vector3;
    [SerializeField] private float speed;

    void Update()
    {
        transform.Rotate(vector3 * speed, Space.Self);
    }
}
