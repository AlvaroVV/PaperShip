using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour {

	public Button _openOptionsButton;
	public Button _closeOptionsButton;
	bool _isOptionsVisible;
	public CanvasGroup _optionsCanvasGroup;

	public Button _quitGameButton;

	public Slider _musicVolumeSlider;
	public Slider _effectsVolumeSlider;

	public Toggle _musicMuteToggle;
	public Toggle _effectsMuteToggle;

	public Dropdown _screenModeDropdown;

	public Button _playButton;
	public CanvasGroup _playCanvasGroup;
	public string _playLevelName = "LevelScene";

	public CanvasGroup rootGroup;

	public CanvasGroup gameOverGroup;

	public CanvasGroup titleGroup;

	public void ShowMenu(){
		rootGroup.alpha = 1;
		rootGroup.interactable = true;
	}

	public void HideMenu(){
		rootGroup.alpha = 0;
		rootGroup.interactable = false;
	}

	public void ShowTitle(){
		titleGroup.alpha = 1;
		titleGroup.interactable = true;
	}

	public void HideTitle(){
		titleGroup.alpha = 0;
		titleGroup.interactable = false;
	}

	public void ShowGameOver(){
		gameOverGroup.alpha = 1;
	}

	public void HideGameOver(){
		gameOverGroup.alpha = 0;
	}


	// Use this for initialization
	void Awake () {
		InitUI();
	}

	void Destroy(){
	}

	void SetVisibleCanvasGroup(CanvasGroup canvasGroup, bool visible){
		// canvasGroup
	}

	void InitUI(){
		if(_openOptionsButton != null){
			_openOptionsButton.onClick.AddListener(delegate{
				if(_optionsCanvasGroup != null){
					_isOptionsVisible = true;
					_optionsCanvasGroup.interactable = _isOptionsVisible;
					_optionsCanvasGroup.alpha = _isOptionsVisible? 1 : 0;
					_optionsCanvasGroup.blocksRaycasts = _isOptionsVisible;

					if(_playCanvasGroup != null){
						_playCanvasGroup.interactable = false;
						_playCanvasGroup.alpha = 0;
						_playCanvasGroup.blocksRaycasts = false;
					}
				}
			});

		}
		if(_closeOptionsButton != null){
			_closeOptionsButton.onClick.AddListener(delegate{
				if(_optionsCanvasGroup != null){
					_isOptionsVisible = false;
					_optionsCanvasGroup.interactable = _isOptionsVisible;
					_optionsCanvasGroup.alpha = _isOptionsVisible? 1 : 0;
				}
				if(_playCanvasGroup != null){
					_playCanvasGroup.interactable = true;
					_playCanvasGroup.alpha = 1;
					_playCanvasGroup.blocksRaycasts = true;
				}
			});
		}
		if(_quitGameButton != null){
			_quitGameButton.onClick.AddListener( delegate{
				Application.Quit();
				Debug.Log("quit");
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
		if(_playButton != null){
			_playButton.onClick.AddListener(delegate{
				HideMenu();
				GameManager.Instance.StartGame();
			});
		}
	}

}
