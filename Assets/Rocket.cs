using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    private bool move;

    public bool colision;

    void Start()
    {
        transform.localPosition = new Vector3(0, 0, 0);
        colision = false;
        move = true;
    }


    void Update()
    {
        if (transform.localPosition.y < -800) { 
            colision = true;
        }
        if (move == true)
        {
            move = false;
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        Debug.Log(Time.deltaTime * 0.0001f);
        yield return new WaitForSeconds(Time.deltaTime * 0.00001f);
        Vector2 poziton = transform.localPosition;
        poziton.y -= 5;
        transform.localPosition = poziton;
        move = true;
    }

}