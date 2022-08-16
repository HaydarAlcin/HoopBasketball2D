using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManagment : MonoBehaviour
{
    public float points;
    public GameObject file, pota, timeManager;
    public float time;
    public bool pointsReady = true;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        TimeManager();
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PointsDetector")
        {
            points++;
            time -= 30;
            if (time<200)
            {
                time = 200;
            }
            timeManager.GetComponent<Slider>().maxValue = time;
            timeManager.GetComponent<Slider>().value = time;

            file.gameObject.GetComponent<Collider2D>().isTrigger = true;
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

        if (other.tag == "AgainPoints")
        {
            file.gameObject.GetComponent<Collider2D>().isTrigger = false;
            //pointsReady = true;
        }
    }

    public void TimeManager()
    {
        
        
        timeManager.GetComponent<Slider>().value -= 1f;
        
        

    }
}
