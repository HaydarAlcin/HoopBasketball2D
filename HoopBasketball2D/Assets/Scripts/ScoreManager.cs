using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public PointsManagment score;

    // Start is called before the first frame update
    void Start()
    {
        score = Object.FindObjectOfType<PointsManagment>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreChange()
    {
        this.gameObject.GetComponent<Text>().text = score.points.ToString();
    }
}
