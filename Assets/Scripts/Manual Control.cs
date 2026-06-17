using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualControl : MonoBehaviour
{
    [SerializeField] Vector3 rotateAmount;
    [SerializeField] FixedJoystick joyStick;
    [SerializeField] float joystickSpeed;
    public bool playerOut = false;
    [SerializeField] Transform centerPoint;

    Rigidbody2D rb;
    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        GameManager.gameOver = false;
        GameManager.cosmic = false;
        GameManager.destructor = false;
    }


    void FixedUpdate()
    {

        // Daily Rotation
        transform.Rotate(rotateAmount * Time.deltaTime);

        // Center of Gravity
        CenterOfGravity();

        Vector3 moveDir = new Vector3(joyStick.Horizontal,joyStick.Vertical,0);
        rb.AddForce(moveDir * joystickSpeed);

        if(GameManager.gameOver)
        {
            Destroy(gameObject.GetComponent<ManualControl>());
        }
    }
   
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Stage") {
            GameManager.gameOver = true;
            if (transform.name == "Cosmic")
            {
                //Debug.Log("Cosmic Out");
                GameManager.destructor = false;
                GameManager.cosmic = true;
            }
            else
            {
                //Debug.Log("Destructor Out");
                GameManager.cosmic = false;
                GameManager.destructor = true;
            }
        }
    }

    private void CenterOfGravity()
    {
        Vector3 dire = (centerPoint.position - transform.position).normalized;
        rb.AddForce (dire * 5);
    }

}
