using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySignsText : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool inRange;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Players"))
        {
            inRange = true;
            Debug.Log("Player in range");
            dialogBox.SetActive(true);
            dialogText.text = dialog;
        }

    }
    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Players"))
        {
            inRange = false;
            Debug.Log("Player out of range");
            dialogBox.SetActive(false);

        }
    }




}
