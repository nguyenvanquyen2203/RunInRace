using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour, IGameStateObserver
{
    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }
    public GameObject scoreBoost;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI scoreOverTxt;
    public TextMeshProUGUI highScoreTxt;
    private float timeBoostScore;
    private float score;
    private int multiScore;
    private bool stopCount;
    private int highScore;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        score = 0;
        multiScore = 1;
        stopCount = true;
        GameManager.Instance.AddObserver(this);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void FixedUpdate()
    {
        if (stopCount) return;
        if (timeBoostScore > 0) timeBoostScore -= Time.fixedDeltaTime;
        else
        {
            multiScore = 1;
            scoreBoost.SetActive(false);
        }
        score += Time.fixedDeltaTime * multiScore;
        scoreTxt.text = ((int)score).ToString();
    }
    public void BoostScore(float timeActive)
    {
        scoreBoost.SetActive(true);
        timeBoostScore = timeActive;
        multiScore = 2;
    }

    public void StartState()
    {
        score = 0;
        scoreTxt.text = ((int)score).ToString();
        stopCount = false;
    }

    public void OverState()
    {
        stopCount = true;
        scoreOverTxt.text = ((int)score).ToString();
        if (highScore < score)
        {
            highScoreTxt.gameObject.SetActive(true);
            highScore = (int)score;
            PlayerPrefs.SetInt("HighScore", (int)score);
        }
        else highScoreTxt.gameObject.SetActive(false);
    }
}
