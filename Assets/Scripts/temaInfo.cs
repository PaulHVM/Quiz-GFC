using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temaInfo : MonoBehaviour {

    public int idTema;
    public GameObject estrela1;
    public GameObject estrela2;
    public GameObject estrela3;

    private int notaFinal;

    // Use this for initialization
    void Start () {

        estrela1.SetActive(false);
        estrela2.SetActive(false);
        estrela3.SetActive(false);

        idTema = PlayerPrefs.GetInt("idTema");
        int notaFinall = PlayerPrefs.GetInt("notaFinal" + idTema.ToString());

        if (notaFinall == 10)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(true);
        }
        else if (notaFinall >= 7)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(true);
            estrela3.SetActive(false);
        }
        else if (notaFinall >= 4)
        {
            estrela1.SetActive(true);
            estrela2.SetActive(false);
            estrela3.SetActive(false);
        }






    }

    // Update is called once per frame
    void Update () {
		
	}
}
