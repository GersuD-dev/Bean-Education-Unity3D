using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolim : MonoBehaviour
{
    public enum Cores
    {
        Marrom,
        Roxo,
        Cinza,
        Laranja,
        Amarelo,
        Vermelho,
        Preto,
        Rosa,
        Verde
    }
    public Cores corPlataforma;
    public bool Player1;
    public string NomePersonagem;
    //public GameObject VerificadorCor;
    public GameObject[] trampolins;
    public float ForçaPulo;
    public Dictionary<string, int> Personagens = new Dictionary<string, int>();

    private void Start()
    {
        trampolins = GameObject.FindGameObjectsWithTag("Trampolim");
    }

    public void ZeraPulos(string key)
    {
        if (Personagens.ContainsKey(key))
        {
            Personagens.Remove(key);
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<PlayerCharacterController> ().corAtual = corPlataforma.ToString ();

            col.gameObject.GetComponent<AudioSource>().Play();

            foreach (var t in trampolins)
            {
                if (t.name != gameObject.name)
                {
                    t.GetComponent<Trampolim>().ZeraPulos(col.gameObject.name);
                }
            }

            if (Personagens.ContainsKey(col.gameObject.name))
            {
                Personagens[col.gameObject.name] = Personagens[col.gameObject.name] + 1; 
                
            }else
            {
                Personagens.Add(col.gameObject.name, 1);    
            }
            NomePersonagem = col.gameObject.name;
            col.GetComponent<PlayerCharacterController>().AdiconaVelocidadeVertical(ForçaPulo /* Personagens[col.gameObject.name]*/);

           
        }
    }
}