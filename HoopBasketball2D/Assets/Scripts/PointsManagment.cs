using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PointsManagment : MonoBehaviour
{
    public float points;
    public GameObject file, pota, timeManager;
    public GameObject timeColor; //Süre azaldýðýnda rengi deðiþtirmek için bir nesne tanýmlýyoruz.

    public GameObject gameOverPanel;
    ScoreManager Score;

    public float time;
    public bool pointsReady = true;

    public float redColor;
    public float greenColor;
    public float blueColor;
    public float colorChange = 0.02f;

    public float maxTimeValue;

    
    public bool gameOver;
    public bool wall;

    public bool crash;
    // Start is called before the first frame update
    void Start()
    {
        
        gameOver = false;
        wall = false;
        Score = Object.FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        TimeManager();
        

        if (timeManager.GetComponent<Slider>().value < time/1.5f)
        {

            redColor= timeColor.GetComponent<Image>().color.r;
            blueColor = timeColor.GetComponent<Image>().color.b;
            greenColor = timeColor.GetComponent<Image>().color.g;
            
            redColor += colorChange;
            timeColor.GetComponent<Image>().color = new Color(redColor,greenColor,blueColor);

            if (timeManager.GetComponent<Slider>().value < time/3)
            {
                redColor += colorChange;
                greenColor -= colorChange;
                blueColor -= colorChange;
                timeColor.GetComponent<Image>().color = new Color(1, greenColor, blueColor);
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        


        if (other.tag == "PointsDetector")
        {
            
            points++;
            gameOver = false;
            crash = false;
            
            
            Score.ScoreChange();

            time -= 30;
            if (time<250)
            {
                time = 200;
            }
            
            timeColor.GetComponent<Image>().color = new Color(0.5f,1f , 0.3f);
            
            timeManager.GetComponent<Slider>().maxValue = time;
            timeManager.GetComponent<Slider>().value = time;

            file.gameObject.GetComponent<Collider2D>().isTrigger = true;
            StartCoroutine(HoopTrigger());
            if (points%2==0)
            {
                pota.gameObject.transform.position = new Vector3(-5f,Random.Range(-2f,6f),transform.position.z);
                pota.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                this.gameObject.GetComponent<BallController>().teleportLeft = true;
                this.gameObject.GetComponent<BallController>().teleportRight = true;
            }
            if(points % 2 == 1)
            {
                pota.gameObject.transform.position = new Vector3(5.25f, transform.position.y, transform.position.z);
                pota.gameObject.transform.rotation = new Quaternion(0, -180,0,0);
                this.gameObject.GetComponent<BallController>().teleportRight = true;
                this.gameObject.GetComponent<BallController>().teleportLeft = true;
            }



            //pointsReady = false;
            //other.GetComponentsInParent<Transform>.position = new Vector2(Random.Range(-5,10), Random.Range(0, 8));
            //other.gameObject.GetComponentInParent<Transform>().position= new Vector2(Random.Range(-5, 10), Random.Range(0, 8));
        }



        //Süre bittiðinde top eðer yere deðiyorsa GameOverPaneli açmamýz gerek Çünkü Top süre bittiðinde havada olabilir ve düþtüðünde basket olabilir.
        
    }

    public void TimeManager()
    {
        //maxTimeValue = timeManager.GetComponent<Slider>().maxValue;

        timeManager.GetComponent<Slider>().value -= 1f;

        if (timeManager.GetComponent<Slider>().value==0)
        {
            gameOver = true;
            StartCoroutine(GameOverControl());
        }
        

    }

    IEnumerator HoopTrigger()
    {
        
        yield return new WaitForSeconds(0.3f);
        file.gameObject.GetComponent<Collider2D>().isTrigger = false;

    }

    //public void GameOverControl()
    //{
    //    if (gameOver==true&&wall==true)
    //    {
    //        gameOverPanel.SetActive(true);
    //        gameOverPanel.gameObject.GetComponent<CanvasGroup>().DOFade(1, 1f);
    //    }
    //}

    IEnumerator GameOverControl()
    {
        //Süre bittiðinde top eðer yere deðiyorsa GameOverPaneli açmamýz gerek Çünkü Top süre bittiðinde havada olabilir ve düþtüðünde basket olabilir.
        yield return new WaitForSeconds(1.5f);
        if (gameOver==true && crash==true)
        {
            gameOverPanel.SetActive(true);
            gameOverPanel.gameObject.GetComponent<CanvasGroup>().DOFade(1, 1f);
            gameOverPanel.transform.GetChild(1).GetComponent<Text>().text = points.ToString();
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="BottomWall")
        {
            crash = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag=="BottomWall")
        {
            crash = false;
        }
    }
}
