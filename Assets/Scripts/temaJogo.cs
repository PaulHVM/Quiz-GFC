using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // Habilitar os componentes de UI no sistema.
using UnityEngine.SceneManagement;
using UnityEngine;


public class temaJogo : MonoBehaviour {

    //Declaração de variáveis

    public Button       btnPlay;
    public Text         txtNomeTema;
    public GameObject   infoTema;
    public Text         txtInfoTema;
    public GameObject   estrela1;
    public GameObject   estrela2;
    public GameObject   estrela3;

    //Banco de Dados fake 
    public string[]     nomeTema;
    public int          numeroQuestoes;


    private int         idTema;



    // Use this for initialization
    void Start () {

        //idTema = 1;
        btnPlay.interactable = false;
        infoTema.SetActive(false);
        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);
        txtInfoTema.text = "";




    }


    public void SelecioneTema(int i){
        idTema = i;


        int notaFinal = PlayerPrefs.GetInt("notaFinal" + idTema.ToString());
        int acertos = PlayerPrefs.GetInt("acertos" + idTema.ToString());
        infoTema.SetActive(false);
        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);


        txtNomeTema.text = nomeTema[idTema];
        txtInfoTema.text = "Você acertou  " + acertos.ToString() + " de " + numeroQuestoes.ToString() + " questões";

        if (notaFinal == 10)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);
        }
        else if (notaFinal >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        }
        else if (notaFinal >= 4)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }


        PlayerPrefs.SetInt("idTema", idTema);

        txtNomeTema.text = nomeTema[idTema];
        infoTema.SetActive(true);
        btnPlay.interactable = true;




    }

    public void Jogar(){

        SceneManager.LoadScene( "T"+idTema.ToString());
         

    }



	// Update is called once per frame
	void Update () {
		
	}
}
