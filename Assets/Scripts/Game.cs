using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] float timeFade;
    [SerializeField] UnityEngine.UI.Image imageFade;
    [SerializeField] SoundManager _soundManager;
    void Start()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
    }

    public void RestartLevel()
    {
        _soundManager.Play("lose");
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        float i = 0;
        while (i <= 1)
        {
            imageFade.color = new Color(0, 0, 0, i);
            i += 0.02f;
            yield return new WaitForSeconds(timeFade);
        }
        int restart = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(restart);


    }
}
