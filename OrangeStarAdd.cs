﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeStarAdd : MonoBehaviour {

    public GameObject explosion;
    public GameObject explosion2;
    GameObject GameController;

    void Start()
    {
        GameController = GameObject.Find("GameController");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Earth")
        {
            GameController.GetComponent<GameController>().SubLives(2);
            Instantiate(explosion2, transform.position, transform.rotation);
        }
        if (other.gameObject.tag == "Player")
        {
            GameController.GetComponent<GameController>().AddScore(20);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
