using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopMovement : MonoBehaviour
{
    public GameObject changePosition;
    public bool change=true;
    
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
        ChangePosition();
    }
    public void ChangePosition()
    {
        if (changePosition.GetComponent<PointsManagment>().pointsReady.ToString()=="False"&& change==true)
        {
            this.gameObject.GetComponent<Transform>().position= new Vector2(Random.Range(-5, 8), Random.Range(-5, 3));
            change = false;
        }
        if (changePosition.GetComponent<PointsManagment>().pointsReady.ToString() == "True")
        {
            change = true;
        }
        
    }
}
