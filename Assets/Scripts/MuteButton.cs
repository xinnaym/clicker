using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite _muteSprite;
    [SerializeField] private Sprite _unmuteSprite;

    private void Start()
    {
        _icon.sprite = AudioManager.Instance.IsMuted
            ? _muteSprite
            : _unmuteSprite;
    }

    public void ToggleMute()
    {
        AudioManager.Instance.ToggleMute();

        _icon.sprite = AudioManager.Instance.IsMuted
            ? _muteSprite
            : _unmuteSprite;
    }
}