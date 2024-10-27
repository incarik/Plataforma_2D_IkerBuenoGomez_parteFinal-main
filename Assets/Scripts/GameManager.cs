using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int coins = 0;
    private bool isPaused;
    [SerializeField] GameObject _pauseCanvas;
    [SerializeField] Text _coinText;
    private Animator _pausePanelAnimator;
    [SerializeField] GameObject _victoryCanvas;
    private bool pauseAnimation;
    private int starsCollected = 0;
    [SerializeField] GameObject[] estrellasActivadas;
    [SerializeField]private Slider _healthBar;
    [SerializeField] private AudioClip victoryClip;
    private BGMManager bgmManager;

    void Awake()
     {
         if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
        }

        Time.timeScale = 1;
        _victoryCanvas.SetActive(false);

        _pausePanelAnimator = _pauseCanvas.GetComponentInChildren<Animator>();
     }

     public void Pause()
     {
        if(!isPaused && !pauseAnimation)
        {
            Time.timeScale = 0;
            isPaused = true;
            _pauseCanvas.SetActive(true);
        }
        else if(isPaused && !pauseAnimation)
        {
           StartCoroutine(ClosePauseAnimation());
           pauseAnimation = true;
        }

    IEnumerator ClosePauseAnimation()
    {
        _pausePanelAnimator.SetBool("Close",true);

        yield return new WaitForSecondsRealtime(0.50f);

        Time.timeScale = 1;
            isPaused = false;
            _pauseCanvas.SetActive(false);

            pauseAnimation = false;
    }
     }

   public void AddCoin()
   {
    coins++;
    _coinText.text = coins.ToString();
   }

   public void SetHealthBar(int maxHealth)
   {
    _healthBar.maxValue = maxHealth;
    _healthBar.value = maxHealth;
   }

   public void AddStar()
   {
    starsCollected++;

    if (starsCollected - 1 < estrellasActivadas.Length)
    {
        estrellasActivadas[starsCollected - 1].SetActive(true);
    }

     if (starsCollected >= 4)
        {
            _victoryCanvas.SetActive(true);
            if (bgmManager != null && victoryClip != null)
            {
                bgmManager.PlayBGM(victoryClip);
            }

            Time.timeScale = 0;
        }
   }

   public void UpdateHealthBar(int health)
   {
        _healthBar.value = health;
   }

   public void SceneLoader(string sceneName)
   {
    SceneManager.LoadScene(sceneName);
   }
}