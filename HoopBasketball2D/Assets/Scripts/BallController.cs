using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rbPlayer;
    public float jumpForceX;
    public float jumpForceY;

    public float yatayEksen;
    public bool teleportLeft, teleportRight;
    



    void Start()
    {
        Time.timeScale = 1.8f;
        rbPlayer = GetComponent<Rigidbody2D>();

        teleportLeft = true;
        teleportRight = true;
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
        //if (Input.GetKeyDown(KeyCode.Space) && rbPlayer.velocity.x >= 0)
        //{

        //    //rbPlayer.AddForce(new Vector2(jumpForceX, jumpForceY));
        //    rbPlayer.velocity = new Vector2(jumpForceX, jumpForceY);

        //}

        //if (Input.GetKeyDown(KeyCode.Space) && rbPlayer.velocity.x < 0)
        //{

        //    rbPlayer.velocity = new Vector2(-jumpForceX, jumpForceY);
        //}

        if (Input.GetKeyDown(KeyCode.Space) && this.gameObject.GetComponent<PointsManagment>().points%2==0)
        {
            rbPlayer.velocity = new Vector2(-jumpForceX, jumpForceY);
        }
        if (Input.GetKeyDown(KeyCode.Space) && this.gameObject.GetComponent<PointsManagment>().points % 2 == 1)
        {
            rbPlayer.velocity = new Vector2(jumpForceX, jumpForceY);
        }

    }


    private void OnTriggerEnter2D(Collider2D wall)
    {
        if (wall.name=="LeftWall"&& teleportLeft == true)
        {
            teleportRight = false;
            yatayEksen = this.gameObject.transform.position.x;
            yatayEksen = -yatayEksen;
            this.gameObject.transform.position = new Vector3(yatayEksen, transform.position.y, transform.position.z);
            teleportLeft = true;
        }
        if (wall.name=="RightWall")
        {
            teleportLeft = false;
            yatayEksen = this.gameObject.transform.position.x;
            yatayEksen = -yatayEksen;
            this.gameObject.transform.position = new Vector3(yatayEksen, transform.position.y, transform.position.z);
            teleportRight=true;

        }
    }

    

}
