using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEffector : MonoBehaviour {

    /*Contador que lleva el tiempo*/
    float time;

	// Use this for initialization
	void Start () {
        /*Se inicializa con 0*/
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        /*Contador del tiempo*/
        time = time+Time.deltaTime;
        Debug.Log(time+"");
        if(time >= 5)
        {
            /*Se para el efecto de particulas y se activa*/
            gameObject.SetActive(false);
            gameObject.SetActive(true);
            time = 0;
        }        
	}
}
