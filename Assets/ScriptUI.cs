using UnityEngine;
using UnityEngine.UIElements;

public class ScriptUI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public UIDocument uiDocument;

    void Start()
    {
        var root = uiDocument.rootVisualElement;
        var boton = root.Q<Button>("Fire1");
        //boton.clicked += () => Debug.Log("¡Clic!");
        boton.clicked += function1;

    }

    void function1()
    {
       Debug.Log("¡Fire!!!");

    }
}
