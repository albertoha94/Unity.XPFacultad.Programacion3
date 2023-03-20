using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField] private string nombre;
    [SerializeField] private Sprite icono;
    [SerializeField][TextArea] private string descripcion;

    public string Nombre => nombre;
    public Sprite Icono => icono;
    public string Descripcion => descripcion;

    public virtual void Usar(Player player) { }
}
