using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CupScript : MonoBehaviour
{
    public bool hasWater;
    public bool hasTea;
    public bool hasMilk;
    public bool hasSugar;
    public TextMeshProUGUI textToString;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "WaterBucket")
        {
            if (hasWater)
            {
                textToString.text = ("The cup already has hot water");
            }
            else
            {
                hasWater = true;
            }

        }
        if (col.tag == "Teabag")
        {
            if (hasWater)
            {
                hasTea = true;
            }
        }
        if (col.tag == "Milk")
        {
            if (hasTea)
            {
                hasMilk = true;
            }
        }
        if (col.tag == "Sugar")
        {
            if (hasMilk)
            {
                hasSugar = true;
                StartCoroutine("TeaMade");
            }
        }
    }
    IEnumerator TeaMade()
    {
        yield return new WaitForSeconds(2f);
    }
}
