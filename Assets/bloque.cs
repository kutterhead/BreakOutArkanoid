using UnityEngine;

public class bloque : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool tienePremio = false;
    public int vidasCelda = 1;
    public gameManager manager;
    public GameObject[] items;

    void Start()
    {
        manager = GameObject.FindFirstObjectByType<gameManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.eliminaCelda();

        if (tienePremio)
        {
            Instantiate(items[0],transform.position,transform.rotation);
        }

        Destroy(gameObject);
        
    }


}
