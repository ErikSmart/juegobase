using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara_handle : MonoBehaviour
{
    public GameObject min;
    public GameObject max;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject billi = GameObject.Find("Bill");
        //Estableciendo limites de la camara
        if ((billi.transform.position.x > max.transform.position.x) && max.transform.position.x < GameObject.FindGameObjectWithTag("Nivel").GetComponent<level_handle>().max.transform.position.x)
        {
            transform.position += new Vector3(0.02f, 0, 0);
        }

    }
}
