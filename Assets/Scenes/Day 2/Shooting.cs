using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float speed;
    public float recoilDistance;
    public float stoppingDistance;
    public Transform player;

    private float timeBtwShots;
    public float startTimeBtwShots;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectsWithTag("Player");
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance) //se o player está longe
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position,
               speed * Time.deltaTime); //inimigo se aproxima
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && 
            Vector2.Distance(transform.position, player.position) > recoilDistance) //inimigo não esta nem tão perto nem tão longe
            //na distancia ideal
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < recoilDistance) //o player estiver muito perto: inimigo recua
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


    }
}
