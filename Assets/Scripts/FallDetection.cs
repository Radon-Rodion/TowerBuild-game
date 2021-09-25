using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDetection : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag == "Item"){
			SceneManager.LoadScene(2);
		}
	}
}
