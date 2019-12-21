using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymachine : MonoBehaviour
{
    public GameObject enemy,enemy01, area1;
    public GameObject[] enemies;
    Vector3 randomLocation;
    private float timer,timer2 = 0;
    private int mach;
    private float boyut;
    public float hardLevel = 0;
    void Start()
    {
        enemies = new GameObject[3];
        enemies[0] = enemy;
        enemies[1] = enemy01;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 35-(hardLevel*300))
        {
            timer++;
        }
        else
        {
            timer = 0;
            machine();
        }
        hardest();
    }
    void machine()
    {
        randomLocation = Random.insideUnitSphere * 4.8f;
        mach = Random.Range(0, 2);
        boyut = Random.Range(0.55f, 1.21f);
        if (mach == 0)
        {
            enemies[0].transform.localScale = new Vector3(boyut, boyut, boyut);
        }
        Instantiate(enemies[mach], area1.transform.position + randomLocation, enemies[mach].transform.rotation);
    }
    void hardest()
    {
        if (hardLevel <= 0.010f)
        {
            if (timer2 < 60 * 2.5f)
            {
                timer2++;
            }
            else
            {
                timer2 = 0;
                hardLevel += 0.001f;
            }
        }
    }
}
