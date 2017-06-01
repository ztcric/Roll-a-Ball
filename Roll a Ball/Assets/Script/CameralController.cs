﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameralController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;


	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position + offset;

        // as we move our player, the camera moves with it.
	}

   
}
