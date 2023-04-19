
using UnityEngine;

public class Pausa : MonoBehaviour
{
    private bool pausaActiva;
    public GameObject menuPausa;
    public GameObject menuHud;
    public TestSound testSound;

    void Update()
    {
        TogglePause();
    }
    void TogglePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausaActiva == true)
            {
                ResumirJuego();
            }
            else
            {
                PausarJuego();
            }
        }

    }
    public void PausarJuego()
    {
        Time.timeScale = 0.05f;
        menuPausa.SetActive(true);
        menuHud.SetActive(false);
        pausaActiva = true;
        TestSound.PausarAudio();

    }

    public void ResumirJuego()
    {
        Time.timeScale = 1;
        menuPausa.SetActive(false);
        menuHud.SetActive(true);
        pausaActiva = false;
        TestSound.PlayAudio();


    }
    public void ResumirMenu()
    {
        Time.timeScale = 1;

    }
}
