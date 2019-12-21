using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathEffect : MonoBehaviour
{
    private Sprite[] _deathEffect;
    public GameObject effect,effect01,effect02;
    private GameObject[] effects;
    
    public bool _bomb = false;
    public Vector3 bombpos;
    public bool instant;
    private GameObject ins;
    void Start()
    {
        effects = new GameObject[3];
        effects[0] = effect;
        effects[1] = effect01;
        effects[2] = effect02;

    }

    // Update is called once per frame
    void Update()
    {
        if (_bomb)
        {
            Instantiate(effects[Random.Range(0,3)], bombpos, effect.transform.rotation);
            _bomb = false;
        }
    }
}
