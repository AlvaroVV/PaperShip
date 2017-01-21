using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenuManager : MonoBehaviour {

	public Button _openOptionsButton;
	public Button _closeOptionsButton;
	bool _isOptionsVisible;
	public CanvasGroup _optionsCanvasGroup;

	public Button _quiteGameButton;

	public Slider _musicVolumeSlider;
	public Slider _effectsVolumeSlider;

	public Toggle _musicMuteToggle;
	public Toggle _effectsMuteToggle;

	public Dropdown _screenModeDropdown;


	// Use this for initialization
	void Awake () {
		// SettingsManager.Instance.OnSettingsReady += InitUI;
		InitUI();
	}

	void Destroy(){
		SettingsManager.Instance.OnSettingsReady -= InitUI;
	}

	void SetVisibleCanvasGroup(CanvasGroup canvasGroup, bool visible){
		// canvasGroup
	}

	void InitUI(){
		if(_openOptionsButton != null){
			if(_optionsCanvasGroup != null){
				_openOptionsButton.onClick.AddListener(delegate{
					_isOptionsVisible = true;
					_optionsCanvasGroup.interactable = _isOptionsVisible;
					_optionsCanvasGroup.alpha = _isOptionsVisible? 1 : 0;
				});
			}
		}
		if(_closeOptionsButton != null){
			if(_optionsCanvasGroup != null){
				_closeOptionsButton.onClick.AddListener(delegate{
					_isOptionsVisible = false;
					_optionsCanvasGroup.interactable = _isOptionsVisible;
					_optionsCanvasGroup.alpha = _isOptionsVisible? 1 : 0;
				});
			}
		}
		if(_quiteGameButton != null){
			_quiteGameButton.onClick.AddListener( delegate{
				Application.Quit();
				});
		}


		if(_musicVolumeSlider != null){
			_musicVolumeSlider.value = SettingsManager.Instance.GetMusicVolume();
			_musicVolumeSlider.onValueChanged.AddListener( delegate{
				SettingsManager.Instance.SetMusicVolume( _musicVolumeSlider.value ); });
		}
		if(_musicMuteToggle != null){
			_musicMuteToggle.isOn = SettingsManager.Instance.IsMusicMuted();
			_musicMuteToggle.onValueChanged.AddListener(delegate{
				SettingsManager.Instance.SetMusicMute(_musicMuteToggle.isOn);
				});
		}

		if( _effectsVolumeSlider != null){
			_effectsVolumeSlider.value = SettingsManager.Instance.GetEffectsVolume();
			_effectsVolumeSlider.onValueChanged.AddListener( delegate{
				SettingsManager.Instance.SetEffectsVolume( _effectsVolumeSlider.value ); });
		}
		if(_effectsMuteToggle != null){
			_effectsMuteToggle.isOn = SettingsManager.Instance.IsEffectsMuted();
			_effectsMuteToggle.onValueChanged.AddListener(delegate{
				SettingsManager.Instance.SetEffectsMute(_effectsMuteToggle.isOn);});

		}

		if(_screenModeDropdown != null){
			Screen.fullScreen = SettingsManager.Instance.IsFullScreen();
			_screenModeDropdown.onValueChanged.AddListener(delegate{
				Debug.Log("dropdown value " + _screenModeDropdown.value);
				if(_screenModeDropdown.value == 0){
					SettingsManager.Instance.SetFullScreen(true);
				}
				else{
					SettingsManager.Instance.SetFullScreen(false);
				}
			});
		}
	}

}
