using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;
using UnityEngine.UIElements;

public class gameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int cols = 10;
    public int rows = 10;
    public GameObject prefabLadrillo;
    //public GameObject[] ladrillosTodos; 
    public Transform puntero;
    public int offSetX = 100;
    public float offSetY = 50;
    public GameObject bola;

    public int celdasTotales = 0;
    [SerializeField] int puntos = 0;

    float initialX = 0;
    void Start()
    {
        puntos = 0;
        int indexAux = 0;
        int indiceEspecial = Random.Range(0, celdasTotales);
        celdasTotales = cols * rows;
        //pposiciona al principio
        puntero.position = new Vector3((-cols / 2)* offSetX, puntero.position.y, puntero.position.z);

        initialX = puntero.position.x;
        //inicializar posición puntero

        for (int y = 0; y < rows; y++)//responsable de cada fila
        {

            for (int x = 0; x < cols; x++)//responsable de cada columna
            {
                GameObject ladrilloActual = Instantiate(prefabLadrillo, puntero.transform.position, puntero.transform.rotation);
                
                ladrilloActual.GetComponent<bloque>().manager = this;

                
                if (indexAux== indiceEspecial)
                {
                    ladrilloActual.GetComponent<bloque>().tienePremio = true;
                    ladrilloActual.GetComponent<SpriteRenderer>().color = Color.green;
                }
                ladrilloActual.GetComponent<bloque>().manager = this;



                puntero.Translate(Vector3.right * offSetX);
                indexAux++;
               
            }
            puntero.transform.position = new Vector3(initialX, puntero.transform.position.y - offSetY, puntero.transform.position.z);


        }  
        puntero.gameObject.SetActive(false);
        Vector2 normalized = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        bola.GetComponent<Rigidbody2D>().linearVelocity = normalized * 10;
    }

    // Update is called once per frame
    public void eliminaCelda()
    {
        celdasTotales--;
        if (celdasTotales<1)
        {
            bola.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
            Debug.Log("Pantalla superada");
            puntos += 100;
        }
        else
        {
            puntos += 1;

        }
        Debug.Log("Puntos: " + puntos);
    }
    public void sumaPuntos(int pts)
    {
        puntos += pts;
        Debug.Log("Puntuación: " + puntos);
    }

}
