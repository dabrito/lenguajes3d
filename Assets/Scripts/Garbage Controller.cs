using UnityEngine;

public class GarbageController : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        Destroy(collision.gameObject);
    }
}
