using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Game : MonoBehaviour
{
    [SerializeField] float timeFade;
    [SerializeField] UnityEngine.UI.Image imageFade;
    [SerializeField] SoundManager _soundManager;
    [SerializeField] TextMeshProUGUI _textPoints;
    [SerializeField] int _points;
    void Start()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        UpdateInfo();
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
    void AddOnePoint()
    {
        _points++;
        UpdateInfo();
    }
    private void UpdateInfo()
    {
        _textPoints.text = _points.ToString();
    }
    private void OnEnable()
    {
        Ball.OnCollidedDot += AddOnePoint;
    }
    private void OnDisable()
    {
        Ball.OnCollidedDot -= AddOnePoint;
    }
}
