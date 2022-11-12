using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public PlayerController myController;
    [SerializeField] List<AudioClip> sShoot = new List<AudioClip>();
    AudioSource myAudioSource;
    public Transform prefabProjectile;
    public float projectileStartSpeed = 20;
    public float offsetFowardShoot = 1;
    public float timeBetweenShots = 0.5f;
    private float timeShoot = 0;
    private void Start()
    {
        myAudioSource  = GetComponent<AudioSource>();
    }
    void Update()
    {
        timeShoot -= Time.deltaTime;
        if (myController.wantToShoot && timeShoot <= 0)
        {
            int nbSoundShoot = Random.Range(0,sShoot.Count);
            myAudioSource.clip = sShoot[nbSoundShoot];
            myAudioSource.Play();
            timeShoot = timeBetweenShots;
            //Création du projectile au bon endroit
            Transform proj = GameObject.Instantiate<Transform>(prefabProjectile, transform.position + transform.forward * offsetFowardShoot, transform.rotation);

            //Ajout d'une implusion de depart
            proj.GetComponent<Rigidbody>().AddForce(transform.forward * projectileStartSpeed, ForceMode.Impulse);
           // proj.GetComponent<Rigidbody>().velocity = Vector3.forward * projectileStartSpeed;
        }
    }
}
