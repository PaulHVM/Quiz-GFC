using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class responder : MonoBehaviour
{

    private int idTema;

    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoRespostas;
    public GameObject CertoA;
    public GameObject ErradoA;


    public string[] perguntas;      // ARmazena todas as perguntas
    public string[] AlternativaA;   // Armezena todas as alterantivas A
    public string[] AlternativaB;   // Armezena todas as alterantivas B
    public string[] AlternativaC;   // Armezena todas as alterantivas C
    public string[] AlternativaD;   // Armezena todas as alterantivas D
    public string[] corretas;       // Armezena todas as alterantivas corretas



    private int idPergunta;

    private float acertos;
    private float qtdQuestoes;
    private float media;
    private int notaFinal;


    // Use this for initialization
    void Start()
    {   
        idTema = PlayerPrefs.GetInt("idTema");
        idPergunta = 0;
        qtdQuestoes = perguntas.Length;
        // print(qtdQuestoes);
        pergunta.text = perguntas[idPergunta];
        respostaA.text = AlternativaA[idPergunta];
        respostaB.text = AlternativaB[idPergunta];
        respostaC.text = AlternativaC[idPergunta];
        respostaD.text = AlternativaD[idPergunta];

        infoRespostas.text = "Respondendo pergunta " + (idPergunta + 1).ToString() + " de " + qtdQuestoes.ToString();


    }

    public void resposta(string alternativa)
    {

        // verifica se escolheo a alternativa certa.

        if (alternativa == "A")
        {
            if (AlternativaA[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
                CertoA.SetActive(true);
                ErradoA.SetActive(false);
            }
            else {
                CertoA.SetActive(false);
                ErradoA.SetActive(true);

            }
        }
        else if (alternativa == "B")
        {
            if (AlternativaB[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }
        else if (alternativa == "C")
        {
            if (AlternativaC[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }
        else if (alternativa == "D")
        {
            if (AlternativaD[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
            }
        }

      //  proximaPergunta();

    }

    public void proximaPergunta(){

        idPergunta++;

        if (idPergunta >= qtdQuestoes){

            // calcula a media
            media = 10 * (acertos / qtdQuestoes);

            // arredonda a nota
            notaFinal = Mathf.RoundToInt(media);

            //verifica se a nota é maior que a anterior

            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString())){

                PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal);
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int) acertos);

            }

            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal);
            PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);
            SceneManager.LoadScene("notaFinal");

        }



        pergunta.text = perguntas[idPergunta];
        respostaA.text = AlternativaA[idPergunta];
        respostaB.text = AlternativaB[idPergunta];
        respostaC.text = AlternativaC[idPergunta];
        respostaD.text = AlternativaD[idPergunta];

        infoRespostas.text = "Respondendo pergunta " + (idPergunta + 1).ToString() + " de " + qtdQuestoes.ToString();



    }

}