using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScriptUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nick;
    [SerializeField] private TMP_Text titulo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void cambiarNick()
    {
        titulo.text = nick.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
