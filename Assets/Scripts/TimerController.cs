using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
	public GameObject secondsLeftTextField;
	public GameObject gameController;
	public float timeInterval = 5f;
	float timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft>0){
			timeLeft -= Time.deltaTime;
		} else {
			gameController.GetComponent<GameController>().placeItem();
			timeLeft = timeInterval;
		}
		secondsLeftTextField.GetComponent<Text>().text=""+((int)timeLeft+1);
    }
}
