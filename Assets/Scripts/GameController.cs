using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public float rotateItemSpeed = 5f;
	public float moveItemSpeed = 3f;
	
	public GameObject heightLevel;
	public GameObject current = null;
	public static int curHeight = 0;
	public static Quaternion cameraDirection;
	
	public GameObject[] items;
	public GameObject levelItem;
	
	public int itemsOnLevel=4;
	private int leftOnLevel;
	
	public void Start(){
		cameraDirection = Quaternion.Euler(0,0,0);
		leftOnLevel = itemsOnLevel;
		curHeight = 2;
	}
	
    public void placeItem(){
		
		if(current!=null) {
			current.GetComponent<Rigidbody>().useGravity = true;
			current.transform.Translate(Vector3.up * -25);
			getCurHeight();
		}
		
		if(leftOnLevel>0){
			int itemIndex = Random.Range (0, items.Length);
			current = Instantiate (items[itemIndex], new Vector3(0,curHeight+32,0), Quaternion.identity);
			leftOnLevel--;
		} else {
			current = Instantiate (levelItem, new Vector3(0,curHeight+32,0), Quaternion.identity);
			leftOnLevel = itemsOnLevel;
		}
	}
	
	void getCurHeight(){
		if(heightLevel.transform.position.y > curHeight) {
			curHeight = (int)heightLevel.transform.position.y;
			//Debug.Log(""+curHeight);
		}
		heightLevel = current;
	}
	
	void Update(){
		if(current!=null){

			if(Input.GetKey(KeyCode.Q))
				current.transform.Rotate(Vector3.up, rotateItemSpeed*15*Time.deltaTime);
			if(Input.GetKey(KeyCode.E))
				current.transform.Rotate(Vector3.up, -rotateItemSpeed*15*Time.deltaTime);
			if(Input.GetKey(KeyCode.W))
				current.transform.Translate(cameraDirection * Vector3.forward * moveItemSpeed*Time.deltaTime);
			if(Input.GetKey(KeyCode.S))
				current.transform.Translate(cameraDirection * Vector3.forward * (-moveItemSpeed)*Time.deltaTime);
			if(Input.GetKey(KeyCode.A))
				current.transform.Translate(cameraDirection * Vector3.left * moveItemSpeed*Time.deltaTime);
			if(Input.GetKey(KeyCode.D))
				current.transform.Translate(cameraDirection * Vector3.left * (-moveItemSpeed)*Time.deltaTime);
		}
	}
}
