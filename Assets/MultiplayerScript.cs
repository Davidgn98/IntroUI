using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.PackageManager;
using UnityEditor.SearchService;
using Unity.VisualScripting;

public class MultiplayerScript : MonoBehaviour
{
    public Canvas menuCrearPartida;
    public Canvas menuSala;

    private string nickJugador;
    public Button botonMulti;

    public TMP_InputField TextNick;
    public GameObject menuMulti;
    public GameObject menuNick;
    public GameObject menuMain;

    public List<JugadorMulti> listadoJugadores;

    private string nombreSala;
    private int numeroJugadores;
    private int modoJuego; // 0-5
    private string passwd;
    private Toggle isPrivateSala;

    private TMP_InputField nombrePartida;
    private TMP_InputField pass;
    private TMP_Text error;
    private TMP_Dropdown gameMode;
    private Slider numJugadores;
    private Toggle isPrivate;

    private JugadorMulti jugador;
    private string[] arrColor = { "#FF0000", "#00FF00", "#0000FF" };

    // Start is called before the first frame update
    void Start()
    {
        jugador = new JugadorMulti(1, "", "");
        foreach (var item in menuCrearPartida.GetComponentsInChildren<TMP_InputField>())
        {
            if(item.name == "NombrePartida")
            {
                nombrePartida = item;
            }
            if (item.name == "Contraseņa")
            {
                pass = item;
                pass.gameObject.SetActive(false);
            }
            
        }
        gameMode = menuCrearPartida.GetComponentInChildren<TMP_Dropdown>();
        numJugadores = menuCrearPartida.GetComponentInChildren<Slider>();
        isPrivate = menuCrearPartida.GetComponentInChildren<Toggle>();
        foreach (var item in menuCrearPartida.GetComponentsInChildren<TMP_Text>())
        {
            if (item.name == "Validacion")
            {
                error = item;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void validarDatos()
    {
        error.text = string.Empty;
        if (nombrePartida.text.Trim().Length == 0)
        {
            error.text = "El nombre esta vacio";
        }
        if(isPrivate.isOn)
        {
            if (pass.text.Trim().Length == 0)
            {
                error.text = "La contraseņa esta vacia";
            }

        }
        if(error.text.Trim().Length == 0)
        {
            CrearSala(nombrePartida.text.Trim(), pass.text.Trim(), gameMode.value, ((int)numJugadores.value)*2);
        }
    }

    void CrearSala(string nomPar, string password, int modJuego, int jugadoresNum)
    {
        nombreSala = nomPar;
        numeroJugadores = jugadoresNum;
        modoJuego = modJuego;
        passwd = password;


        foreach (var item in menuSala.GetComponentsInChildren<TMP_Text>())
        {
            if (item.name == "Titulo")
            {
                item.text = nombreSala;
            }
            if (item.name == "Jugador1")
            {
                item.text = jugador.Nombre;
            }
            if (item.name == "ModoJuego")
            {
                if (modJuego == 0)
                {
                    item.text = "Duelo por Equipos";
                }
                else if (modJuego == 1)
                {
                    item.text = "Capturar la Bandera";
                }
                else if (modJuego == 2)
                {
                    item.text = "Punto Caliente";
                }
            }
            if (item.name == "NumJugadores")
            {
                item.text = jugadoresNum.ToString();
            }
            if (item.name == "Pass")
            {
                isPrivateSala = menuSala.GetComponentInChildren<Toggle>();
                isPrivate.interactable = false;
                if (passwd.Length != 0)
                {
                    
                    isPrivateSala.isOn = true;
                    item.text = passwd;
                }
                else
                {
                    isPrivateSala.isOn = false;
                    item.text = "";
                }
                
            }

        }
        foreach (var item in menuSala.GetComponentsInChildren<RawImage>())
        {
            if (item.name == "Color")
            {
                Color newCol;
                if (UnityEngine.ColorUtility.TryParseHtmlString(jugador.Color, out newCol))
                {
                    item.color = newCol;
                }
            }
        }
        //listadoJugadores.Add(jugador);
        menuCrearPartida.gameObject.SetActive(false);
        menuSala.gameObject.SetActive(true);
    }

    public void ComprobarNombre()
    {
        if (jugador.Nombre == "")
        {
            menuMain.SetActive(false);
            menuNick.SetActive(true);
        }
        else
        {
            menuMain.SetActive(false);
            menuMulti.SetActive(true);  
        }
    }

    public void SetNick()
    {
        if (TextNick.text.Trim().Length != 0)
        {
            jugador.Nombre = TextNick.text;
        }
    }

    private void assignColor()
    {
        //TODO
    }
}
