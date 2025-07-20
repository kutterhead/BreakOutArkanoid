using UnityEngine;

public class bloque : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool tienePremio = false;
    public int vidasCelda = 1;
    public gameManager manager;
    public GameObject[] items;
    public int indexItem = 0;



    void Start()
    {
        manager = GameObject.FindFirstObjectByType<gameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.eliminaCelda();

        if (tienePremio)
        {
            GameObject bola =  Instantiate(items[indexItem], transform.position, transform.rotation);
            if (indexItem==0)
            {
                lanzaBola(bola);
            }
            
        }

        Destroy(gameObject);
        
    }

    void lanzaBola(GameObject bola)
    {

        Vector2 normalized = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        bola.GetComponent<Rigidbody2D>().linearVelocity = normalized * 10;
        manager.bolasPantalla++;
    }


}
