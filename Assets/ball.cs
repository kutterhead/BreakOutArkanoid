using UnityEngine;

public class ball : MonoBehaviour

{
    public gameManager manager;

    AudioSource fuente;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuente = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        fuente.pitch = Random.Range(0.9f, 1.1f);
        fuente.Play();
        if (collision.gameObject.CompareTag("gameOver"))
        {
            Debug.Log("Bola eliminada.");
            //bola fuera, llamada a manager
            Destroy(gameObject);

        }
    }
}
