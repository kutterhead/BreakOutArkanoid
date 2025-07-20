using UnityEngine;

public class ball : MonoBehaviour

{
    public gameManager manager;

    AudioSource fuente;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fuente = GetComponent<AudioSource>();
        manager = FindAnyObjectByType<gameManager>();
        manager.bolasPantalla++;
    }

  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        fuente.pitch = Random.Range(0.9f, 1.1f);
        fuente.Play();
        if (collision.gameObject.CompareTag("gameOver"))
        {
            Debug.Log("Bola eliminada.");
            //bola fuera, llamada a manager
            
            manager.restaBola();
            Destroy(gameObject);

        }
    }



}
