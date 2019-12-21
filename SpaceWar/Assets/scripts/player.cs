using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Joystick joystick;
    public GameObject[] healthbar;
    float runSpeed = 0.12f;
    public GameObject x1, x2, y1, y2;
    private Vector2 direction;
    public int health = 3;
    public int score = 0;
    public Text _score;
    public Sprite _sprite,_mainSprite,motor1,motor2;
    private bool assagi, yukari, main;
    private bool birdefa = true;
    private float motoranimsüre = 0;
    private int degistir = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        healthbar = new GameObject[3];
        healthbar[0] = GameObject.Find("health1");
        healthbar[1] = GameObject.Find("health2");
        healthbar[2] = GameObject.Find("health3");
        GetComponent<Rigidbody2D>().mass = 0f;
        _score = GameObject.Find("_score").GetComponent<Text>();
        _mainSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        moving();
        _health();
        motorAnim();
    }
    void moving()
    {
        if (transform.position.x <= x2.transform.position.x && transform.position.x >= x1.transform.position.x)
        {
            direction = new Vector2(joystick.Direction.y * -1, joystick.Direction.x);
            transform.Translate(direction * runSpeed);
            if (direction.x == 0)
            {
                if (birdefa)
                {
                    birdefa = false;
                    gameObject.GetComponent<SpriteRenderer>().sprite = _mainSprite;
                }
                yukari = false;
                assagi = false;
            }
            if (direction.x > 0 && !assagi)
            {
                birdefa = true;
                assagi = true;
                yukari = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = _sprite;
                gameObject.transform.localScale = new Vector3(2, 2, 1);
            }
            if (direction.x < 0 && !yukari)
            {
                birdefa = true;
                yukari = true;
                assagi = false;
                gameObject.GetComponent<SpriteRenderer>().sprite = _sprite;
                gameObject.transform.localScale = new Vector3(-2,2,1);
            }
            

        }
        else
        {
            if (transform.position.x >= x2.transform.position.x)
            {
                transform.position = new Vector2(x2.transform.position.x, transform.position.y);
            }
            if (transform.position.x <= x1.transform.position.x)
            {
                transform.position = new Vector2(x1.transform.position.x, transform.position.y);
            }
        }
        if (transform.position.y >= y2.transform.position.y && transform.position.y <= y1.transform.position.y)
        {
            direction = new Vector2(joystick.Direction.y * -1, joystick.Direction.x);
            transform.Translate(direction * runSpeed);
        }
        else
        {
            if (transform.position.y <= y2.transform.position.y)
            {
                transform.position = new Vector2(transform.position.x, y2.transform.position.y);
            }
            if (transform.position.y >= y1.transform.position.y)
            {
                transform.position = new Vector2(transform.position.x, y1.transform.position.y);
            }
        }
    }

    void _health()
    {
        if (health == 0)
        {
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene("deathscreen");
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "enemy")
        {
            health--;
            healthbar[health].SetActive(false);
            Destroy(coll.gameObject);
            Handheld.Vibrate();
        }
    }
    void motorAnim()
    {
        if (motoranimsüre <= 45)
        {
            motoranimsüre++;
        }
        else
        {
            motoranimsüre = 0;
            degistir *= -1;
            if(degistir == -1) GameObject.Find("motor").GetComponent<SpriteRenderer>().sprite = motor1;
            if(degistir == 1) GameObject.Find("motor").GetComponent<SpriteRenderer>().sprite = motor2;
        }
    }
}