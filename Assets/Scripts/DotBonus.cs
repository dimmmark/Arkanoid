using System.Collections;
using UnityEngine;

public class DotBonus : MonoBehaviour
{
    [SerializeField] GameObject[] _stars;
    [SerializeField] BonusLife _lifeBonusPrefab;
    [SerializeField] Game _game;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] int _bonusTuched;
    [SerializeField] GameObject _bonusIcon;
    public static event System.Action OnAddBonusLife;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _bonusTuched++;
        BonusStarOn();
        if(_bonusTuched == 6)
        {
            OnAddBonusLife?.Invoke();
            _bonusTuched = 0;
            BonusStarOn();
            StartShowBonus();
        }
    }
    private void BonusStarOn()
    {
        for (int i = 0; i < _stars.Length; i++)
        {
            if(i < _bonusTuched)
            {
                _stars[i].SetActive(true);
                
            }
            else
                _stars[i].SetActive(false);
        }
    }
    void StartShowBonus()
    {
        StartCoroutine(nameof(ShowBonus));
    }
    IEnumerator ShowBonus()
    {
        _bonusIcon.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        _bonusIcon.SetActive(false);
    }
}
