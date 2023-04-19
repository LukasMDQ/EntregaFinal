using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.Playables;

public class DataControler : MonoBehaviour
{
   
    public GameObject Jugador;
    public string datosGuardados;
    public DatosJuego datosJuego = new DatosJuego ();
    
   
    private void Awake()
    {
        datosGuardados = Application.dataPath + "/datosJuego.json";
        Jugador = GameObject.FindGameObjectWithTag("Personaje");
        CargarPartida();
    }
   
    public  void CargarPartida()
    {
        if (File.Exists(datosGuardados)) 
        {
            string Contenido = File .ReadAllText (datosGuardados);
            datosJuego = JsonUtility.FromJson<DatosJuego>(Contenido);
            Debug.Log("Posicion del Jugador: " + datosJuego.playerPos);
            Debug.Log("vida del jugador" + datosJuego.hpJugador);
            Jugador.transform.position = datosJuego.playerPos;
            Jugador.GetComponent<STATS>().maxHP = datosJuego.hpJugador;         
            Jugador.GetComponent<STATS>().maxMP = datosJuego.mpJugador;
            Jugador.GetComponent<STATS>().maxEXP = datosJuego.expJugador;
            Jugador.GetComponent<STATS>().LVL = datosJuego.lvlJugador;
            Jugador.GetComponent<STATS>().Damage = datosJuego.damageJugador;
        }
        else
        {
            Debug.Log("El archivo no existe");
        }
    }
    public void GuardarPartida()
    {
        DatosJuego nuevosDatos = new DatosJuego()
        {
            playerPos = Jugador.transform.position,
            hpJugador = Jugador.GetComponent<STATS>().maxHP,
            mpJugador = Jugador.GetComponent<STATS>().maxMP,
            expJugador = Jugador.GetComponent<STATS>().maxEXP,
            baseHpJugador = Jugador.GetComponent<STATS>().hp,
            baseMpJugador = Jugador.GetComponent<STATS>().mp,
            damageJugador = Jugador.GetComponent<STATS>().Damage,
            lvlJugador = Jugador.GetComponent<STATS>().LVL

        };
        String cadenaJSON = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(datosGuardados, cadenaJSON);
        Debug.Log("Archivo Guardado");
       

    }


  
}
