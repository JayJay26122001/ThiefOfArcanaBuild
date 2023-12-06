using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    // Esse codigo serve para gerar pedaços de terreno e randomizar a ordem do proximo que virar alem de fazer ser infinito
    //P.S cada pedaço de terra QUE O PLAYER FOR PISAR NÃO AO REDOR, tem que ter 50 ou 100 de escala em Z para que isso funciona, se não tera buracos na geração

        public GameObject[] Section;
        public int zPos = 50;
        public bool creatingSection = false;
        public int secNum;
        public int maxSec = 10;

    private void Update()
    {
        if(creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    //Colocar um random.range e adicionar o valor maximo pra cada pedaço novo que for adicionar
    IEnumerator GenerateSection()
    {
        if(transform.childCount >= maxSec)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        secNum = Random.Range(0, 6);
        GameObject newSection = Instantiate(Section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        newSection.transform.parent = transform;
        zPos += 50;
        yield return new WaitForSeconds(10);
        //creatingSection como falso novamente é o que faz resetar o processo
        creatingSection = false;
    }


}
