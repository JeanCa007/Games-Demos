using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemananger : MonoBehaviour
{
    public bool wait = false;
    public int tiempowait;
    public string nombrewait;

    private void Start()
    {
        if (wait)
        {
            StartCoroutine(Esperar(nombrewait,tiempowait));
        }
    }

    public IEnumerator Esperar(string scene,int time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }

    public void CambioEscena(string nombreScena)
    {
        SceneManager.LoadScene(nombreScena);
    }

}
