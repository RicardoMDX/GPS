using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameItself : MonoBehaviour {

    private int stage;

    private float range;

    public Text myMessage;
    public Text myPosition;
    public Text myDistance;

    private float target1Lat = 51.588918f; //Grove
    private float target1Long = -0.230614f;
    private float target2Lat = 51.589810f; //College Building
    private float target2Long = -0.228714f;
    private float target3Lat = 51.590124f; //MDX House
    private float target3Long = -0.230718f;
    private float target4Lat = 51.590448f; //Library
    private float target4Long = -0.229523f;
    private float dist = 0f;

    // Use this for initialization
    void Start () {
        stage = 1;
        range = 3.0f;
        myMessage.text = "Starting..!";
	}
	
	// Update is called once per frame
	void Update () {
        checkPosition(); //My position
        checkStage();		
	}

    void checkStage(){

        switch (stage)
        {
            case 1:
                myMessage.text = "Go to Grove Building";
                break;
            case 2:
                myMessage.text = "Go to College Building!";
                break;
            case 3:
                myMessage.text = "Go to MDX House!";
                break;
            case 4:
                myMessage.text = "Go to Shepperd Library!";
                break;
            case 5:
                myMessage.text = "You Win!";
                break;
        }
    }

    void checkPosition(){
        float currentLat =  this.GetComponent<GPSGetter>().myLat;
        float currentLong = this.GetComponent<GPSGetter>().myLong;
        switch (stage)
        {
            case 1:
                dist = Haversine(currentLat, target1Lat, currentLong, target1Long);
            break;
            case 2:
                dist = Haversine(currentLat, target2Lat, currentLong, target2Long);
                break;
            case 3:
                dist = Haversine(currentLat, target3Lat, currentLong, target3Long);
                break;
            case 4:
                dist = Haversine(currentLat, target4Lat, currentLong, target4Long);
                break;
        }       
        if (range>=dist){
            stage = stage++;
        }
        myPosition.text = (currentLat + "," + currentLong);
        myDistance.text = dist.ToString();
    }

    private  float Haversine(float lat1, float lat2, float lon1, float lon2)
    {
        float r = 6371.0f; // meters
        float dlat = (lat2 - lat1) / 2;
        float dlon = (lon2 - lon1) / 2;

        float q = Mathf.Pow(Mathf.Sin(dlat), 2) + Mathf.Cos(lat1) * Mathf.Cos(lat2) * Mathf.Pow(Mathf.Sin(dlon), 2);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(q), Mathf.Sqrt(1 - q));

        float d = r * c;
        return d*10; //1000
    }
}
