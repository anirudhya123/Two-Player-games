using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpuseCreation : MonoBehaviour
{
    [Header("Beyblade Hit Sound Effects")]
    [SerializeField] AudioClip[] sounds;
    Rigidbody2D rb;
    [Header("BeyBlade hit Effect Prefeab")]
    [SerializeField] GameObject prefab;
    AudioManager audioManager;
    float oppositeImpact;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Anti")
        {
            Vector3 collPoint = collision.collider.ClosestPoint(transform.position);
            GameObject newobj = Instantiate(prefab, collPoint,Quaternion.identity);
            audioManager.PlayRandom(sounds);
            ApplyImpulse(collision.collider);
            Destroy(newobj,1);
        }
    }

    void ApplyImpulse(Collider2D collision)
    {
        // Impact Force
        if (GameManager.singlePlayer)
            oppositeImpact = 7f;
        else
            oppositeImpact = 4f;

        Rigidbody2D oppositeRb = collision.gameObject.GetComponent<Rigidbody2D>();
        Vector2 newDir = (collision.transform.position - transform.position);
        newDir.Normalize();
        oppositeRb.AddForce(newDir * oppositeImpact, ForceMode2D.Impulse);
        rb.AddForce(-newDir * 4f, ForceMode2D.Impulse);
    }

    
}
