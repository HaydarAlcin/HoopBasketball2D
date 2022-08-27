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

        if (Input.touchCount>0)
        {
            Touch parmak = Input.GetTouch(0);

            if (parmak.phase==TouchPhase.Began && this.gameObject.GetComponent<PointsManagment>().points % 2 == 0)
            {
                if (this.gameObject.GetComponent<PointsManagment>().gameOver == false)
                {
                    rbPlayer.velocity = new Vector2(-jumpForceX, jumpForceY);
                }
            }
            if (parmak.phase == TouchPhase.Began && this.gameObject.GetComponent<PointsManagment>().points % 2 == 1)
            {
                if (this.gameObject.GetComponent<PointsManagment>().gameOver == false)
                {
                    rbPlayer.velocity = new Vector2(jumpForceX, jumpForceY);
                }

            }
        }
    }


    private void OnTriggerEnter2D(Collider2D wall)
    {
        if (wall.name=="LeftWall")
        {
            teleportRight = false;
            yatayEksen = this.gameObject.transform.position.x;
            yatayEksen = -yatayEksen;
            this.gameObject.transform.position = new Vector3(6, transform.position.y, transform.position.z);
            

            RightWallCheck();
        }
        if (wall.name=="RightWall")
        {
            teleportLeft = false;
            yatayEksen = this.gameObject.transform.position.x;
            yatayEksen = -yatayEksen;
            this.gameObject.transform.position = new Vector3(-5.68f, transform.position.y, transform.position.z);
            
            LefttWallCheck();
        }
    }

    IEnumerator RightWallCheck()
    {
        yield return new WaitForSeconds(0.01f);
        teleportRight = true;

    }
    IEnumerator LefttWallCheck()
    {
        yield return new WaitForSeconds(0.01f);
        teleportLeft = true;

    }



}
