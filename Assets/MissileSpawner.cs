using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSpawner : MonoBehaviour
{
    public float timeBetweenLaunch;
    public Transform Spawner;
    public Transform theRotation; //put the base itself here
    public GameObject Missile;
    private void Start()
    {
        Invoke("launching",timeBetweenLaunch);
    }
    void launching()
    {
        Instantiate(Missile,Spawner.position ,theRotation.rotation);
        Start();

    }

}
