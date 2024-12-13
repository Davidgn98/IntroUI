using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMulti
{
    private int id;
    private string nombre;
    private string color;
    
    public JugadorMulti(int newid, string newnombre, string newcolor) 
    {
        id = newid;
        nombre = newnombre;
        color = newcolor;
    }

    public int Id { get => id; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Color { get => color; set => color = value; }
}
