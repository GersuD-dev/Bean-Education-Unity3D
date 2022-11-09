using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    public float tempo;

    public GameObject Gerson, Daniel, Paula, Malas, Malas2;

    private void Start()
    {
        tempo = 0;
        Gerson.gameObject.SetActive(false);
        Paula.gameObject.SetActive(false);
        Daniel.gameObject.SetActive(false);
        Malas.gameObject.SetActive(false);
        Malas2.gameObject.SetActive(false);
    }
    void Update()
    {
        Debug.Log(tempo);

        tempo += Time.deltaTime;

        if(tempo < 5)
        {
            Malas.gameObject.SetActive(false);
            Malas2.gameObject.SetActive(false);
            Gerson.gameObject.SetActive(true);
        }

        else if (tempo > 5 && tempo < 9)
        {
            Gerson.gameObject.SetActive(false);
            Daniel.gameObject.SetActive(true);
        }
        else if (tempo < 14 && tempo > 10)
        {
            Daniel.gameObject.SetActive(false);
            Paula.gameObject.SetActive(true);
        }
        else if (tempo < 16.5f && tempo > 15)
        {
            Paula.gameObject.SetActive(false);
            Malas.gameObject.SetActive(true);
            Malas2.gameObject.SetActive(true);
        }
        else if (tempo > 16.5f ){ tempo = 0; }
    }
}
