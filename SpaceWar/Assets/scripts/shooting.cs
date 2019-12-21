using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour
{
    public GameObject bullet, rockett;
    public GameObject Player;
    public GameObject canvas, rocket;
    public Image img,rocketButton;
    public bool touched = false;
    private AudioSource aud,rocketAudio;
    private bool _shoot,clicked = false;
    private int timer = 0;
    public bool atesetti = false;

    private GameObject cam;
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        img = canvas.GetComponent<Image>();
        rocketButton = rocket.GetComponent<Image>();
        aud = Player.GetComponent<AudioSource>();
        rocketAudio = rockett.GetComponent<AudioSource>();
        rocketAudio.enabled = true;
    }
    private void Update()
    {
        if (clicked)
        {
            if (timer < 60 * 3)
            {
                timer++;
            }
            else
            {
                timer = 0;
                clicked = false;
            }
        }
    }

    public void Shoot()
    {
        if (cam.GetComponent<pixelAnim>().atesEdebilir == true)
        {
            atesetti = true;
            hotMotorAnim();
            img.color = new Color32(255, 4, 205, 200);
            aud.Play(0);
            Vector2 bulletPosition = new Vector2(Player.transform.position.x + 0.5f, Player.transform.position.y);
            GameObject shoot = (GameObject)Instantiate(bullet, bulletPosition, Player.transform.rotation);
            Destroy(shoot, 1.45f);
        }
    }
    public void launchRocket()
    {
        rocketButton.color = Color.red;
        if (clicked == false)
        {
            Vector2 rocketPosition = new Vector2(Player.transform.position.x + 1.3f, Player.transform.position.y);
            GameObject rocket = (GameObject)Instantiate(rockett, rocketPosition, Player.transform.rotation);
            Destroy(rocket, 3f);
            clicked = true;
        }
    }
    public void _iftouch()
    {
        atesetti = false;
        img.color = new Color32(255, 4, 114, 200);
        rocketButton.color = new Color32(255,4, 114, 200);
    }


    void hotMotorAnim()
    {
        cam.GetComponent<pixelAnim>().hotMeterAnim();
    }
}
