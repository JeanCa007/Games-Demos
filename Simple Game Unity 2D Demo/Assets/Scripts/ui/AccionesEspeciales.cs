using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccionesEspeciales : MonoBehaviour
{
    public GameObject canva1;
    
    // Start is called before the first frame update
    void Start()
    {

    }
  

private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canva1.SetActive(true);
            
        }

      

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canva1.SetActive(false);

        }

        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
