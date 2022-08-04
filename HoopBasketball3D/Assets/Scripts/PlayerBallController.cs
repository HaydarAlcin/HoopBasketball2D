using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallController : MonoBehaviour
{
    Rigidbody rbPlayer;
    public float jumpForceX;
    public float jumpForceY;
    

    void Start()
    {
        Time.timeScale = 2;
        rbPlayer = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerBallJump();
    }

    private void FixedUpdate()
    {
        //PlayerBallJump();
    }

    public void PlayerBallJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rbPlayer.AddForce(new Vector2(jumpForceX, jumpForceY));
            rbPlayer.velocity = new Vector2(jumpForceX, jumpForceY);
            
            

            
        }
    }
}
