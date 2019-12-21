using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemywalk : MonoBehaviour
{
    public GameObject bullet;
    private RectTransform earthDamage;
    private GameObject cam;
    private float timer = 0;
    private float time = 60*2;
    private float zaxis = 0.007f;
    private int _random, _randomstart, reduceCount;
    private int döndür = 1;
    void Start()
    {
        reduceCount = 0;
        _randomstart = Random.Range(0, 2) * 2 - 1;
        cam = GameObject.Find("Main Camera");
        earthDamage = GameObject.Find("earthDamage").GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyWalk();
        //enemyShoot();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "wall")
        {
            reduceCount += 80;
            earthDamage.sizeDelta = new Vector2(earthDamage.rect.width-reduceCount, earthDamage.rect.height);
            earthDamage.position = new Vector2(earthDamage.position.x-(reduceCount/2),earthDamage.position.y);
            Destroy(gameObject);
            if (earthDamage.rect.width == 0)
            {
                SceneManager.LoadScene("deathscreen");
            }
        }
        if(col.gameObject.name == "wallup")
        {
            if(gameObject.name == "enemy(Clone)")
            {
                döndür *= -1;
            }
        }
        if(col.gameObject.name == "walldown")
        {
            if (gameObject.name == "enemy(Clone)")
            {
                döndür *= -1;
            }
        }
        if(col.gameObject.name == "enemy(Clone)"  || col.gameObject.name == "enemy01(Clone)")
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), col.collider);
        }
    }

    void enemyWalk()
    {
        if (gameObject.name == "enemy(Clone)")
        {
            transform.Rotate(new Vector3(0, 0, 6*_randomstart));

            transform.position += new Vector3(-0.055f-cam.GetComponent<enemymachine>().hardLevel, 0.01f*_z()*döndür, 0);
        }
        else
        {
            transform.position += new Vector3(-0.065f-cam.GetComponent<enemymachine>().hardLevel, 0, 0);
        }
    }
    int _z()
    {
        if (time <= 60*2)
        {
            time++;
        }
        else
        {
            time = 0;
            _random = Random.Range(0, 2) * 2 - 1;
        }
        return _random;
    }
    /* void enemyShoot()
     {

         if (timer <= 180)
         {
             timer++;
         }
         else
         {
             Vector2 bulletPosition = new Vector2(transform.position.x-1f, transform.position.y);
             GameObject shoot = (GameObject)Instantiate(bullet, bulletPosition, bullet.transform.rotation);
             timer = 0;
         }
     }*/
}
