using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class particleMagneticEffect : MonoBehaviour
{
    private ParticleSystem m_System;
    private ParticleSystem.Particle[] m_Particles;
    private float m_Drift = 0.075f;
    private GameObject player;
    private GameObject magnetic;
    public AudioClip aud;
    void Start()
    {
        magnetic = GameObject.Find("magnetic");
        m_System = GetComponent<ParticleSystem>();
        m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        int numParticlesAlive = m_System.GetParticles(m_Particles);
        for (int i = 0; i < numParticlesAlive; i++)
        {
            if(Mathf.Abs(m_Particles[i].position.x-magnetic.transform.position.x) < 0.5f && Mathf.Abs(m_Particles[i].position.y - magnetic.transform.position.y) < 0.5f)
            {
                m_Particles[i].remainingLifetime = 0;
                player.GetComponent<player>().score++;
                player.GetComponent<player>()._score.text =""+ player.GetComponent<player>().score;
                AudioSource.PlayClipAtPoint(aud,m_Particles[i].position);
            }
            m_Particles[i].position += calculateDirection(m_Particles[i]) * m_Drift;
        }
        m_System.SetParticles(m_Particles,numParticlesAlive);
        
    }
    Vector3 calculateDirection(ParticleSystem.Particle part)
    {
        Vector3 pos = magnetic.transform.position;
        Vector3 dir = (pos-part.position).normalized;
        return dir;
    }
}
