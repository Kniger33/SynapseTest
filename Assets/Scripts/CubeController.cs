using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeController : MonoBehaviour {

    public GameObject playCube;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        playCube.transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

	}

    public void LoadSecondWindow()
    {
        SceneManager.LoadScene("MainWindow");
    }
}
