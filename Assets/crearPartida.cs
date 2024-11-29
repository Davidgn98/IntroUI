using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class crearPartida : MonoBehaviour
{
    public TMP_Text texto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void validarDatos()
    {
        InputField[] campos = GetComponents<InputField>();
        foreach (var campo in campos)
        {
            if (campo.name == "NombrePartida")
            {
                if(campo.GetComponent<Text>().text == "")
                {
                    texto.enabled = true;
                }
            }
        }

    }
}
