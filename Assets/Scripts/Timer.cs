using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public  GameObject Inner;
    private float timeDuration = 6f;

    private float _time;

    [SerializeField] private TextMeshProUGUI FirstMinute;
    [SerializeField] private TextMeshProUGUI SecondMinute;
    [SerializeField] private TextMeshProUGUI Separator;
    [SerializeField] private TextMeshProUGUI FirstSecond;
    [SerializeField] private TextMeshProUGUI SecondSecond;

    public TextMeshProUGUI textPLayer1;
    public TextMeshProUGUI textPLayer2;
    public TextMeshProUGUI winner;
    private float flashtimer;
    private float flashduration = 1f;
    void Start()
    {
        ResetTimer();
    }

    
    void Update()
    {
        if (_time > 0)
        {
            _time -= Time.deltaTime; //cada frame o actualizacion tomaremos el tiempo entre ellas 
            UptadeTimerDisplay(_time);
        }
        else {
            flash();
        }
        
    }

    private void ResetTimer() {
        _time = timeDuration;
    }

    private void UptadeTimerDisplay(float time) {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        FirstMinute.text = currentTime[0].ToString();
        SecondMinute.text = currentTime[1].ToString();
        FirstSecond.text = currentTime[2].ToString();
        SecondSecond.text = currentTime[3].ToString();
    }
    private void flash() {
        if (_time != 0) {
            _time = 0;
            //SceneManager.LoadScene("EndGameMenu");
            Inner.GetComponent<GridManager>().ContColor();
            textPLayer1.text = "P1: " + Inner.GetComponent<GridManager>().getP1();
            textPLayer2.text = "P2: " + Inner.GetComponent<GridManager>().getP2();
            if (Inner.GetComponent<GridManager>().getP1() > Inner.GetComponent<GridManager>().getP2())
            {
                winner.text = "Player 1 GAna";
            }
            else if (Inner.GetComponent<GridManager>().getP1() < Inner.GetComponent<GridManager>().getP2())
            {
                winner.text = "Player 2 Gana";
            }
            else {
                winner.text = "Empate";
            }
            UptadeTimerDisplay(_time);
        }
        if (flashtimer <= 0)
        {
            flashtimer = flashduration;
        }
        else if (flashtimer >= flashduration / 2)
        {
            flashtimer -= Time.deltaTime;
            SetTextDisplay(false);

        }
        else {
            flashtimer -= Time.deltaTime;
            SetTextDisplay(true);
        }
    }

    private void SetTextDisplay(bool enabled) {
        FirstMinute.enabled = enabled;
        SecondMinute.enabled = enabled;
        Separator.enabled = enabled;
        FirstSecond.enabled = enabled;
        SecondSecond.enabled = enabled;
        textPLayer1.enabled = enabled;
        textPLayer2.enabled = enabled;
        winner.enabled = enabled;
    }
}
