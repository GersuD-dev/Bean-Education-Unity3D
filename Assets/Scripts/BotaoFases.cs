using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BotaoFases : MonoBehaviour
{
    public string nomeCenaJogo = "CENA1";

    public bool mudarfase = false;
    private float tempo;

    private void Update()
    {
        if(mudarfase)
        {
            tempo += Time.deltaTime;
        }
        if (tempo > 5 && mudarfase == true)
        {
            Jogar();
        }

    }
    public void Jogar()
    {
        SceneManager.LoadScene(nomeCenaJogo);
    }
}
