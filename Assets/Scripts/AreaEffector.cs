using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffector : MonoBehaviour {

    float time;

	// Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        time = time+Time.deltaTime;
        Debug.Log(time+"");
        if(time >= 5)
        {
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            time = 0;
        }        
	}
}
