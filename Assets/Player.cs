using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float velocidad = 10f;
    public gameManager manager;


    public Transform limiteI;
    public Transform limiteD;
    const float offSetXLimites = 1.5f;


    public AudioClip clipItem;
    AudioSource fuente;
    void Start()
    {
        fuente = gameObject.AddComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (transform.position.x<limiteI.position.x + offSetXLimites )
        {
            Debug.LogWarning("Fuera de límites.");
            transform.Translate(Vector3.right * MathF.Abs(horizontal) * velocidad);

        }
        else if ( transform.position.x > limiteD.position.x - offSetXLimites)
        {
            Debug.LogWarning("Fuera de límites.");
            transform.Translate(Vector3.right * MathF.Abs(horizontal) * -velocidad);


        }
        else
        {

            transform.Translate(Vector3.right * horizontal * velocidad);
        }

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
  
            float velX = manager.bola.transform.position.x - transform.position.x;
            Vector2 normalized = new Vector2(velX / 2.5f, 1f).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = normalized * 10;


        }
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            fuente.clip = clipItem;
            manager.sumaPuntos(100);

            fuente.Play();
        }
    }
}
