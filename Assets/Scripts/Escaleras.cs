using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escaleras : MonoBehaviour
{

    public Nivel nivelInferior;
    public Nivel nivelSuperior;
    private EscalerasTrigger[] triggers;

    private void Awake()
    {
        triggers = transform.GetComponentsInChildren<EscalerasTrigger>();
        triggers[0].nivel = nivelSuperior;  
        triggers[1].nivel = nivelInferior;
    }
}
