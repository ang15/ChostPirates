using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    
    public float health;
    [SerializeField]
    private Slider slider;
    //public List<GameObject> rocket;
    public GameObject rocketPrefab;
    public Transform canvas;
    private bool kill;


    void Start()
    {
        health = 1f;
        slider.value = 1;
        kill = false;
        GameObject rocketNew = Instantiate(rocketPrefab, canvas);
        rocketNew.transform.localPosition = transform.localPosition;
        //rocket.Add(rocketNew);
    }


    void Update()
    {
        slider.value = health;
        //if (kill == false)
        //{
        //    for (int i=0;i<rocket.Count-1;i++)
        //    {
        //        if (rocket[i].GetComponent<Rockets>().colision == true)
        //        {
        //            kill = true;
        //            rocket[i].SetActive(false);
        //            kill = false;
        //        }

        //    }
        //}
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnMouseDown()
    {
        GameObject rocketNew = Instantiate(rocketPrefab, canvas);
        rocketNew.transform.localPosition = transform.localPosition;
        //rocket.Add(rocketNew);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "rocket")
        {
           health-=0.1f;
           collision.gameObject.GetComponent<Rocket>().colision = true;

        }
    }

}