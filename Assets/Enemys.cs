using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    public float health;
    public bool move;
    public int enemyAmount;
    [SerializeField]
    private int enemyAmount2;
    public GameObject[] enemys;
    [SerializeField]
    private Enemys enemy2;
    public float y;
    public bool move2;
    void Start()
    {
        move = true;
    }

    void Update()
    {

         if(transform.localPosition.y > -284)
        {
            //move = false;
            //Vector2 Poziton = transform.localPosition;
            //Poziton.y = 1602;
            //transform.localPosition = Poziton;
            if (move2 == true)
            {
                if (move == true)
                {
                    move = false;
                    StartCoroutine(Move());
                    y = transform.localPosition.y;
                }
            }
        }

        if (enemy2.y <= -300)
        {
      
            move2 = true;
        }

        if (enemyAmount == 0)
        {     
            enemy2.gameObject.SetActive(true);
            y = transform.localPosition.y;

            if (transform.localPosition.y > -1490)
            {
                if (move == true)
                {
                    move = false;
                    StartCoroutine(Move());
                }
            }
            else
            {
                for (int i = 0; i < enemys.Length; i++)
                {
                    enemys[i].SetActive(true);
                    enemys[i].GetComponent<Enemy>().health = 1;
                    enemys[i].GetComponent<Enemy>().CreateRowNew();
                }
                Vector2 Poziton = transform.localPosition;
                Poziton.y = 383;
                transform.localPosition = Poziton;
                move2 = false;
                enemyAmount = enemyAmount2;
            }
        }
    }
    IEnumerator Move()
    {
        Debug.Log(1.1f * Time.deltaTime * 100);
        yield return new WaitForSeconds(1.1f* Time.deltaTime*10);
        Vector2 poziton = transform.localPosition;
        poziton.y -= 10;
        transform.localPosition = poziton;
        move = true;
    }
}
