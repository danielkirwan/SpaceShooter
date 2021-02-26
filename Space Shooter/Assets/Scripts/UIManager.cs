using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Sprite[] _lives;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartLevel;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _gameOverText.gameObject.SetActive(false);
        _restartLevel.gameObject.SetActive(false);
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScoreText(int score)
    {
        _scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        _livesImage.sprite = _lives[currentLives];
        if (currentLives == 0)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
            _gameOverText.gameObject.SetActive(true);
            _restartLevel.gameObject.SetActive(true);
            StartCoroutine(GameOverFlicker());
        _gameManager.GameOver();
    }

    IEnumerator GameOverFlicker()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
