using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool Player1;
    public static bool Player2;
    public GameObject fase, Menu;

    private void Start()
    {
        Player1 = false; Player2 = false;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Caiu no gameover");

            if(col.gameObject.name == "Player1")
            {
                Debug.Log("Player 1 caiu");
                Player1 = true;

                Menu.gameObject.SetActive(false);
                fase.GetComponent<SFase>().VerificaVencedor();

            }
            else if (col.gameObject.name == "Player2")
            {
                Debug.Log("Player 2 caiu");
                Player2 = true;

                Menu.gameObject.SetActive(false);
                fase.GetComponent<SFase>().VerificaVencedor();

            }
        }
    }
}
