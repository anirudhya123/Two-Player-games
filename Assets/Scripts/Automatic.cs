using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Automatic : MonoBehaviour
{
    [SerializeField] GameObject target;
    Rigidbody2D rb;
    [SerializeField ]float forceAmount ;
    [SerializeField] Transform centerPoint;
    [SerializeField] Vector3 rotateAmount;
 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate()
    {
        // Daily Rotation
        transform.Rotate(rotateAmount * Time.deltaTime);

        // Center of Gravity
        CenterOfGravity();

        Attack();

        if(GameManager.gameOver)
        {
            Destroy(gameObject.GetComponent<Automatic>());
        }
    }

    void Attack()
    {
        Vector3 forceDirection = (target.transform.position - transform.position).normalized;
        rb.AddForce (forceDirection * forceAmount);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Stage")
        {
            GameManager.gameOver = true;
            GameManager.destructor = true;
            GameManager.cosmic = false;
            Destroy(gameObject.GetComponent<Automatic>());
        }
    }
    private void CenterOfGravity()
    {
        Vector3 dire = (centerPoint.position - transform.position).normalized;
        rb.AddForce(dire * 5);
    }
}
