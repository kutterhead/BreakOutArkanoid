using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float velocidad = 10f;
    public gameManager manager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right*Input.GetAxis("Horizontal")*velocidad);


        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            //collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            float velX = manager.bola.transform.position.x - transform.position.x;
            Vector2 normalized = new Vector2(velX / 2.5f, 1f).normalized;
            collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = normalized * 10;



            //collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;

        }
    }
}
