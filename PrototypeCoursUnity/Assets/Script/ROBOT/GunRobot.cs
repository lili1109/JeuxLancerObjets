using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRobot : MonoBehaviour
{
    public Robot myController;
    public Transform prefabProjectile;
    public float projectileStartSpeed = 20;
    public float offsetFowardShoot = 1;
    public float timeBetweenShots = 0.5f;
    private float timeShoot = 0;

    void Update()
    {
        timeShoot -= Time.deltaTime;
        if (myController.wantToShoot && timeShoot <= 0)
        {
            timeShoot = timeBetweenShots;
            //Création du projectile au bon endroit
            Transform proj = GameObject.Instantiate<Transform>(prefabProjectile, transform.position + transform.forward * offsetFowardShoot, transform.rotation);

            //Ajout d'une implusion de depart
            proj.GetComponent<Rigidbody>().AddForce(transform.forward * projectileStartSpeed, ForceMode.Impulse);
           // proj.GetComponent<Rigidbody>().velocity = Vector3.forward * projectileStartSpeed;
        }
    }
}
