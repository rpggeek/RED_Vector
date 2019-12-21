using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{
    public AudioClip destroy,rocketAudio;
    private GameObject cam;
    private GameObject player;
    public GameObject explosion,explosion2,explosion3;
    private GameObject target;
    private Vector3 heading,direction;
    private Collider2D[] _target;
    private Collider2D enkücük = null;
    private float minSqrDistance = Mathf.Infinity;
    private bool birdefa = true;
    private int count = 0;
    private bool rotation = true;
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        player = GameObject.Find("player");
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

        target = GameObject.Find("rockett");
    }
    void Update()
    {
        if(gameObject.tag == "rocket")
        {
            _target = Physics2D.OverlapCircleAll(player.transform.position, 35f, LayerMask.GetMask("enemy"), -1 * Mathf.Infinity, Mathf.Infinity);
            if (_target.Length!=0)
            {
                
                if (birdefa)
                {
                    count = 0;
                    for (int i = 0; i < _target.Length; i++)
                    {
                        float sqrDistanceToCenter = (player.transform.position - _target[i].transform.position).sqrMagnitude;
                        if (sqrDistanceToCenter < minSqrDistance)
                        {
                            minSqrDistance = sqrDistanceToCenter;
                            enkücük = _target[i];
                        }
                    }
                    birdefa = false;
                }
                else if (enkücük == null)
                {
                    if (_target[count + 1] != null)
                    {
                        count++;
                        enkücük = _target[count];
                    }
                }
                else
                {
                    heading = enkücük.gameObject.transform.position - gameObject.transform.position;
                    direction = heading.normalized;
                    transform.position += direction * 0.2f;
                    transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
                }
            }
            else
            {
                transform.Translate(Vector2.up * 10 * Time.deltaTime);
            }

        }
        else
        {
            if (rotation)
            {
                rotation = false;
                float random = Random.Range(-2f, 3f);
                transform.rotation = Quaternion.Euler(0, 0, -90 + random);
            }
            transform.Translate(Vector2.up * 10 * Time.deltaTime);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "enemy" && gameObject.tag == "bullet")
        {
            cam.GetComponent<deathEffect>()._bomb = true;
            cam.GetComponent<deathEffect>().instant = true;
            cam.GetComponent<deathEffect>().bombpos = col.gameObject.transform.position;
            AudioSource.PlayClipAtPoint(destroy, col.gameObject.transform.position);
            Destroy(col.gameObject);
            Destroy(gameObject);
            if (col.gameObject.name == "enemy(Clone)")
            {
                GameObject exp = (GameObject)Instantiate(explosion2, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(exp, 3.5f);
            }
            if(col.gameObject.name == "enemy01(Clone)")
            {
                GameObject exp = (GameObject)Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(exp, 3.5f);
            }
        }
        else if (col.gameObject.tag == "enemy" && gameObject.tag == "rocket")
        {
            AudioSource.PlayClipAtPoint(rocketAudio, col.gameObject.transform.position);
            Destroy(col.gameObject);
            Destroy(gameObject);
            if (col.gameObject.name == "enemy(Clone)")
            {
                GameObject exp = (GameObject)Instantiate(explosion3, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(exp, 3.5f);
            }
            if (col.gameObject.name == "enemy01(Clone)")
            {
                GameObject exp = (GameObject)Instantiate(explosion3, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(exp, 3.5f);
            }
        }
        else if(col.gameObject.tag == "rocket" && gameObject.tag == "rocket"){
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(),col.collider);
        }else if(col.gameObject.tag == "Player" && gameObject.tag == "rocket"){
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), col.collider);
        }
        else if(gameObject.tag == "rocket" && col.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
        else
        {
            cam.GetComponent<deathEffect>()._bomb = false;
        }
    }
}