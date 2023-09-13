using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Gun : MonoBehaviour
{
    public int clipSize = 6;
    public int currrentClipSize = 6;
    private AudioSource gunAudio;
    public AudioClip gunShot;
    public GameObject flash;
    private Animator animator;
    public LineRenderer laserPointer;

    public ParticleSystem stoneParticles;

    public ParticleSystem bloodParticles; 

    // muzzle flash
    private void Start()
    {
        animator = flash.GetComponent<Animator>();
        gunAudio = flash.GetComponent<AudioSource>();
    }

    void ShowParticle(ParticleSystem particle, Vector3 position, Quaternion rotation)
    {
        particle.Stop(true,ParticleSystemStopBehavior.StopEmittingAndClear);
        particle.transform.position = position;
        particle.transform.rotation = rotation;
        particle.Play(true);
    }
    public void Aiming()
    {
        
        laserPointer.SetPosition(0, laserPointer.transform.position);
        RaycastHit point;
        if (Physics.Raycast(laserPointer.transform.position, laserPointer.transform.forward, out point))
        {
            print(point.point);
            laserPointer.SetPosition(1,point.point);
        }
    }
    public void Shoot()
    {
        // trigger animtion
        if (currrentClipSize != 0)
        {
            currrentClipSize--;
            gunAudio.PlayOneShot(gunShot);
            //animator.Play("shot");
            animator.SetTrigger("shot");
            
            RaycastHit hit;
            if (Physics.Raycast(flash.transform.position, flash.transform.forward, out hit))
            {
                if(hit.collider != null)
                {
                    Vector3 aimDirection = (hit.point - this.transform.position).normalized;
                    Quaternion rot = Quaternion.LookRotation(-aimDirection, Vector3.up);

                    if (hit.collider.CompareTag("Enemy"))
                    {
                        ShowParticle(bloodParticles, hit.point, rot);
                    }
                    else
                    {
                        ShowParticle(stoneParticles, hit.point, rot);
                    }
                }
            }
            // if enemy deal damage
            // if surface impact particles
        }
    }
}
