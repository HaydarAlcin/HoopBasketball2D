using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManagment : MonoBehaviour
{
    public float points;
    Rigidbody pointRb;
    public bool pointsReady=true;
    // Start is called before the first frame update
    void Start()
    {
        pointRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="PointsDetector"&& pointsReady==true)
        {
            points++;
            pointsReady = false;
            //other.GetComponentsInParent<Transform>.position = new Vector2(Random.Range(-5,10), Random.Range(0, 8));
            
            //other.gameObject.GetComponentInParent<Transform>().position= new Vector2(Random.Range(-5, 10), Random.Range(0, 8));

        }

        if (other.tag=="AgainPoints")
        {
            pointsReady = true;
        }
    }
}
