using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public GameObject rocket;
    public GameObject rocketPrefab;
    private bool kill;
    public Enemys enemys;

    void Start()
    {
        health = 1;
        kill = false;
        CreateRowNew();
    }


    void Update()
    {
        if(kill==false)
        if (rocket.GetComponent<Rocket>().colision == true)
            {
                kill = true;
                Destroy(rocket);
                CreateRowNew();
                kill = false;
            }
        if (health == 0)
        {
            gameObject.SetActive(false);
            enemys.enemyAmount -= 1;
            Destroy(rocket);
        }

    }
    public void CreateRowNew()
    {
        GameObject rocketNew = Instantiate(rocketPrefab, transform);
        rocket = rocketNew;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "rockets")
        {
            health = health - 0.5f;
            Destroy( collision.gameObject);

        }
    }
}
