using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class time : MonoBehaviour
{
    public GameObject clockback;
    public GameObject clock;
    private GameObject player;
    private float arrowCount = 0;
    private int playerHealth;
    private GameObject[] healthBar;

    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (arrowCount == 360)
        {
            arrowCount = 0;

            if (player.GetComponent<player>().health < 3)
            {
                player.GetComponent<player>().health += 1;
                player.GetComponent<player>().healthbar[player.GetComponent<player>().health - 1].SetActive(true);
            }
            
        }
        arrowCount += 0.5f;
        clock.transform.Rotate(new Vector3(0, 0, -0.5f));
    }
    }

