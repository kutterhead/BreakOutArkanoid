using UnityEngine;

public class bloque : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public bool tienePremio = false;
    public int vidasCelda = 1;
    public gameManager manager;

    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.sumaPuntos();
        Destroy(gameObject);
        
    }


}
