using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pixelAnim : MonoBehaviour
{
    public Sprite motor01, motor02;
    public GameObject canvas;
    private GameObject motor1, motor2, motor3;
    private GameObject hotMeter, hotMeterSayac;
    private float time,hotMeterTime,atesMeter = 0;
    private int eksi = -1;
    private bool atesEtti;
    private float _time = 0.7f;
    public bool atesEdebilir=true;

    void Start()
    {
        motor1 = GameObject.Find("motor1");
        motor2 = GameObject.Find("motor2");
        motor3 = GameObject.Find("motor3");
        hotMeter = GameObject.Find("hotMeter");
        hotMeterSayac = GameObject.Find("hotMeterSayac");
        atesEtti = canvas.GetComponent<shooting>().atesetti;
    }

    // Update is called once per frame
    void Update()
    {
        menuMotorAnim();
        hotMeterCooling();
    }
    void menuMotorAnim()
    {
        if (time <= 60)
        {
            time++;
        }
        else
        {
            time = 0;
            eksi *= -1;
            if (eksi == 1)
            {
                if (motor1.gameObject != null)
                {
                    motor1.GetComponent<Image>().sprite = motor01;
                }
                if (motor2.gameObject != null)
                {
                    motor2.GetComponent<Image>().sprite = motor01;
                }
                if (motor3.gameObject != null)
                {
                    motor3.GetComponent<Image>().sprite = motor01;
                }

            }
            else
            {
                if (motor1.gameObject != null)
                {
                    motor1.GetComponent<Image>().sprite = motor02;
                }
                if (motor2.gameObject != null)
                {
                    motor2.GetComponent<Image>().sprite = motor02;
                }
                if (motor3.gameObject != null)
                {
                    motor3.GetComponent<Image>().sprite = motor02;
                }
            }
        }
    }
    public void hotMeterAnim() //53499
    {
        if (hotMeterSayac.transform.position.x <= 1.45f)
        {
            hotMeterSayac.transform.position += new Vector3(0.1f, 0, 0);
        }
        else
        {
            atesEdebilir = false;
        }
    }
    void hotMeterCooling()
    {
        if (canvas.GetComponent<shooting>().atesetti == true)
        {
            _time = 0.7f;
        }
        if (canvas.GetComponent<shooting>().atesetti == false)
        {
            if (hotMeterSayac.transform.position.x >= -1.325f)
            {
                if (hotMeterTime <= 60 * _time)
                {
                    hotMeterTime++;
                }
                else
                {
                    atesEdebilir = true;
                    hotMeterTime = 0;
                    hotMeterSayac.transform.position -= new Vector3(0.1f, 0, 0);
                    if (_time >= 0f)
                    {
                        _time -= 0.15f;
                    }
                }
            }
        }
    }

}
