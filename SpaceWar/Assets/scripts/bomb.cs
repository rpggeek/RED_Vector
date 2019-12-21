﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    private Sprite[] _deathEffect;
    private int sayac = 0;
    void Start()
    {
        _deathEffect = Resources.LoadAll<Sprite>("graphics/spritesheet01");
    }

    // Update is called once per frame
    void Update()
    {
        if (sayac <= 72)
        {
            sayac++;
            GetComponent<SpriteRenderer>().sprite = _deathEffect[sayac];
        }
        else
        {
            sayac = 0;
            Destroy(gameObject);
        }
    }
}
