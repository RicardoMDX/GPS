using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GPSGetter : MonoBehaviour
{

    public float myLat;
    public float myLong;


	private void Start()
	{
        if (Input.location.isEnabledByUser)
        {
            StartCoroutine(GetLocation());
        }
	}

    private IEnumerator GetLocation(){
        // Start service before querying location
        Input.location.Start(1,.1F);
        while (Input.location.status == LocationServiceStatus.Initializing){
            yield return new WaitForSeconds(0.25f);    
        }

        myLat = Input.location.lastData.latitude;
        myLong = Input.location.lastData.longitude;
       
        yield break;
    }

	private void Update()
	{
        myLat = Input.location.lastData.latitude;
        myLong = Input.location.lastData.longitude;
        //GetLocation();       
	}
}