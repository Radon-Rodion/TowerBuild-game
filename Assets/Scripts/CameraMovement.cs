using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
	public GameObject camera;
	public float rotateSpeed = 5f;
	public float moveSpeed = 3f;
   // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
			camera.transform.Rotate(Vector3.up, rotateSpeed*15*Time.deltaTime);
		if(Input.GetKey(KeyCode.RightArrow))
			camera.transform.Rotate(Vector3.up, -rotateSpeed*15*Time.deltaTime);
		if(Input.GetKey(KeyCode.UpArrow))
			camera.transform.Translate(Vector3.up * moveSpeed*Time.deltaTime);
		if(Input.GetKey(KeyCode.DownArrow)&&camera.transform.position.y>0)
			camera.transform.Translate(Vector3.up * (-moveSpeed)*Time.deltaTime);
		GameController.cameraDirection = camera.transform.rotation;
    }
}
