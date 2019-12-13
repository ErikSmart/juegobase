using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_handle : MonoBehaviour
{
    Vector2 velocidad;
    bool is_suelo = false;
    public float vel_desp;
    public GameObject sp_cuerpo;
    public GameObject sp_piernas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicion = transform.position;
        if (Input.GetKeyDown(KeyCode.A))
        {
            /*  posicion.x -= 0.5f;
             transform.position = posicion; */
            velocidad.x = -vel_desp;
            if (!sp_cuerpo.GetComponent<SpriteRenderer>().flipX)
            {
                sp_cuerpo.GetComponent<SpriteRenderer>().flipX = true;
                sp_piernas.GetComponent<SpriteRenderer>().flipX = true;
                sp_cuerpo.transform.position += new Vector3(-0.000011126f, 0, 0);
                sp_piernas.transform.position += new Vector3(-0.000011126f, 0, 0);
                Debug.Log("Tecla A");
            }
            GetComponent<Animator>().SetInteger("estado", 1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            /*  posicion.x += 0.5f;
             transform.position = posicion; */
            velocidad.x = vel_desp;
            if (sp_cuerpo.GetComponent<SpriteRenderer>().flipX)
            {
                sp_cuerpo.GetComponent<SpriteRenderer>().flipX = false;
                sp_piernas.GetComponent<SpriteRenderer>().flipX = false;
                sp_cuerpo.transform.position += new Vector3(+0.000011126f, 0, 0);
                sp_piernas.transform.position += new Vector3(+0.000011126f, 0, 0);

                Debug.Log("Tecla D");
            }
            GetComponent<Animator>().SetInteger("estado", 1);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("Detener tecla");
            velocidad.x = 0.0f;
            GetComponent<Animator>().SetInteger("estado", 0);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("Tecla D");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Tecla D");
        }

    }
    private void FixedUpdate()
    {
        if (!is_suelo)
        {
            //calcula la gravedad 
            velocidad.y += Physics2D.gravity.y * Time.deltaTime;
        }
        GetComponent<Rigidbody2D>().position += velocidad * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D bum)
    {
        if (bum.gameObject.tag == "Suelo")
        {
            if (!is_suelo)
            {
                is_suelo = true;
                velocidad.y = 0.0f;
                Debug.Log("Estas en el suelo ");
            }
        }
    }
}
