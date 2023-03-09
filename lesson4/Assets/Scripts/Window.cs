using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : MonoBehaviour
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _SoundsEffectToggle;
    [SerializeField] private Dropdown _languageDropdown;
    [SerializeField] private Button _facebookConnectButton;
    [SerializeField] private Button _devicesButton;
    [SerializeField] private Button _aboutButton;
    [SerializeField] private Button _helpAndSupportButton;
    // Start is called before the first frame update
    void Start()
    {
        _closeButton.onClick.AddListener(OnCloseButtonHandler);
        _musicToggle.onValueChanged.AddListener(OnMusicToggleHandler);
        _SoundsEffectToggle.onValueChanged.AddListener(OnSoundsEffectToggleHandler);
        _facebookConnectButton.onClick.AddListener(OnFacebookConnectButtonHandler);
        _devicesButton.onClick.AddListener(OnDevicesButtonHandler);
        _aboutButton.onClick.AddListener(OnAboutButtonHandler);
        _helpAndSupportButton.onClick.AddListener(OnHelpAndSupportButtonHandler);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCloseButtonHandler()
    {
        Debug.Log("On Close Button");
    }

    private void OnMusicToggleHandler(bool isOn)
    {
        Debug.Log($"Music toggle {isOn}");
    }

    private void OnSoundsEffectToggleHandler(bool isOn)
    {
        Debug.Log($"Sounds Effect toggle {isOn}");
    }

    private void OnFacebookConnectButtonHandler()
    {
        Debug.Log("On Facebook Connect Button");
    }

    private void OnDevicesButtonHandler()
    {
        Debug.Log("On Devices Button");
    }

    private void OnAboutButtonHandler()
    {
        Debug.Log("On About Button");
    }

    private void OnHelpAndSupportButtonHandler()
    {
        Debug.Log("On Help And Support Button");
    }
}

