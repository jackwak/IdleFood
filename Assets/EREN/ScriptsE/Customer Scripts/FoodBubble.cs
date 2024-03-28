using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodBubble : MonoBehaviour
{
    public BubbleSpritesSO foodBubbleSO;

    private void OnEnable()
    {
        LookCamera();
        SetBubble(this.transform.root.gameObject.GetComponent<Customer>().OrderedFood);

        //this.gameObject.transform.LookAt(GameObject.Find("Main Camera").transform.position, Vector3.up);
        //transform.forward = GameObject.Find("Main Camera").transform.forward * -1;
    }

    public void SetBubble(string foodName)
    {
        switch (foodName)
        {
            case "Lemonade":
                transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = foodBubbleSO.lemonade;
                break;
            default:
                break;
        }

        SetCountText();
    }
    public void LookCamera()
    {
        transform.eulerAngles = new Vector3(GameObject.Find("Main Camera").transform.eulerAngles.x * -1, transform.eulerAngles.y + 180, transform.eulerAngles.z);
    }

    public void SetCountText()
    {
        this.gameObject.transform.Find("Canvas").gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = (this.transform.root.gameObject.GetComponent<Customer>().FoodCount - this.transform.root.gameObject.GetComponent<Customer>().alinanYemekAdedi).ToString();
    }


}
