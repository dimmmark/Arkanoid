using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] int _maxHealth;
    [SerializeField] int _health;
    [SerializeField] float timeFade;
    [SerializeField] UnityEngine.UI.Image imageFade;
    [SerializeField] SoundManager _soundManager;
    [SerializeField] PlayerControls _playerControls;
    [SerializeField] HealthUI _healthUI;
    [SerializeField] TextMeshProUGUI _textPoints;
    [SerializeField] int _points;
    [SerializeField] Ball _ballPrefab;
    void Start()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        _healthUI.Setup(_maxHealth);
        _healthUI.LifeIconOff(_health);
        UpdateInfo();
    }

    public void StartFade()
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
        if (_health > 0)
        {
            imageFade.color = new Color(0, 0, 0, 0);
            _health--;
            _healthUI.LifeIconOff(_health);
            Ball _newBall = Instantiate(_ballPrefab, transform.position, Quaternion.identity);
            _newBall.Init(_playerControls, _soundManager, this);
        }
        else
            RestartLevel();

    }
    public void RestartLevel()
    {
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
