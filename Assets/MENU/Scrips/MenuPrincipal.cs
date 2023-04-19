
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        ReproducirAudio();
        PausarAudio();
    }
    public void Jugar()
    {
       
        
            SceneManager.LoadScene(1);
       
    }
    public void Menu()
    {
        
            SceneManager.LoadScene(0);
        
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void ReproducirAudio()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            TestSound.PlayAudio();
        }
    }
    public void PausarAudio()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TestSound.PausarAudio();
        }
    }
}
