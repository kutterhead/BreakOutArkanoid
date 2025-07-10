using UnityEngine;

public class gameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int cols = 10;
    public int rows = 10;
    public GameObject prefabLadrillo;
    public Transform puntero;
    public int offSetX = 100;
    public float offSetY = 50;
    public GameObject bola;

    float initialX = 0;
    void Start()
    {
        //pposiciona al principio
        puntero.position = new Vector3((-cols / 2)* offSetX, puntero.position.y, puntero.position.z);

        initialX = puntero.position.x;
        //inicializar posición puntero

        for (int y = 0; y < rows; y++)//responsable de cada fila
        {

            for (int x = 0; x < cols; x++)//responsable de cada columna
            {
                Instantiate(prefabLadrillo, puntero.transform.position, puntero.transform.rotation);
                puntero.Translate(Vector3.right * offSetX);
               
            }
            puntero.transform.position = new Vector3(initialX, puntero.transform.position.y - offSetY, puntero.transform.position.z);


        }  
        puntero.gameObject.SetActive(false);
        bola.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(Random.Range(-1f,1f)*10, Random.Range(-1f, 1f)*10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
