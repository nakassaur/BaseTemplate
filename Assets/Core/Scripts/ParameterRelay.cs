using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterRelay : MonoBehaviour
{
    public string param;
    
    public void Relay(int value)
    {
        transform.GetComponent<Animator>().SetInteger(param, value);
    }

    public void Relay(float value)
    {
        transform.GetComponent<Animator>().SetFloat(param, value);
    }
    
}
