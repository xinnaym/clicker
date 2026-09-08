using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RewardAutoClick : MonoBehaviour
{
    [SerializeField] private Button _rewardButton;
    [SerializeField] private Clicker _clicker;
    [SerializeField] private TMP_Text _timerText;

    [Header("Reward Settings")]
    [SerializeField] private float _duration = 30f;
    [SerializeField] private float _clicksPerSecond = 10f;

    private Coroutine _autoClickCoroutine;

    private void Start()
    {
        if (_rewardButton != null)
        {
            _rewardButton.onClick.RemoveAllListeners();
            _rewardButton.onClick.AddListener(OnRewardButtonClicked);
        }

        ResetTimerText();
    }

    private void OnRewardButtonClicked()
    {
        if (_autoClickCoroutine != null)
            StopCoroutine(_autoClickCoroutine);

        _autoClickCoroutine = StartCoroutine(AutoClickRoutine());
    }

    private IEnumerator AutoClickRoutine()
    {
        _rewardButton.interactable = false;

        float remainingTime = _duration;
        float clickTimer = 0f;

        while (remainingTime > 0f)
        {
            float interval = 1f / Mathf.Max(_clicksPerSecond, 0.1f);
            
            clickTimer += Time.deltaTime;
            remainingTime -= Time.deltaTime;

            if (clickTimer >= interval)
            {
                _clicker.TriggerRewardClick();
                clickTimer -= interval;
            }

            if (_timerText != null)
            {
                _timerText.text = $"{Mathf.CeilToInt(remainingTime)} сек.";
            }

            yield return null;
        }

        _rewardButton.interactable = true;
        ResetTimerText();
        _autoClickCoroutine = null;
    }

    private void ResetTimerText()
    {
        if (_timerText != null)
        {
            _timerText.text = $"{Mathf.CeilToInt(_duration)} сек.";
        }
    }
}