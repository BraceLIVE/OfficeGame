using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyAfterDelay(3f));
    }

    void OnCollisionEnter(Collision collision)
    {
        // if (collision.gameObject.CompareTag("Enemy"))
        // {
        //     Destroy(collision.gameObject);
        // }

        Destroy(gameObject);
    }

    IEnumerator DestroyAfterDelay(float delay)
    {
        // Warte für die angegebene Zeit
        yield return new WaitForSeconds(delay);

        // Zerstöre das GameObject nach der Wartezeit
        Destroy(gameObject);
    }
}
