﻿using UnityEngine;
using System.Collections;

public class MovingSliderScript : MonoBehaviour {
    
    public float max = 2.6f;
    public float min = -2.6f;
    public Vector3 basePosition;
    public float value = 1;
    float lengthOfSlider;
    
    void Start () {
        lengthOfSlider = max - min;
    }
	
	void Update () {

	}


    void OnMouseDown()
    {
        basePosition = transform.position;
    }

    void OnMouseDrag()
    {

        Vector3 mousePosition = new Vector3(Input.mousePosition.x, basePosition.y, basePosition.z);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 realPosition = new Vector3(-objPosition.x, basePosition.y, basePosition.z);
        realPosition.x = Mathf.Clamp(realPosition.x, min, max);
        transform.position = realPosition;
    }

    void OnMouseUp()
    {
        value = (transform.position.x - min) / lengthOfSlider;
    }

}