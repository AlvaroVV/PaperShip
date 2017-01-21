using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SettingsManager : MonoBehaviour {

	private static SettingsManager _settingsManager;

	private SettingsManager() {

	}

	public static SettingsManager Instance{
			get {
					if (_settingsManager == null)
							_settingsManager = new SettingsManager();
					return _settingsManager;
			}
	}

	void Awake(){
		DefaultSettings();
		LoadSettings();
	}

	void DefaultSettings(){
		if(!PlayerPrefs.HasKey("MusicVolume")){
			PlayerPrefs.SetFloat("MusicVolume", 1);
		}
		if(!PlayerPrefs.HasKey("MusicMuted")){
			PlayerPrefs.SetInt("MusicMuted", 0);
		}
		if(!PlayerPrefs.HasKey("EffectsVolume")){
			PlayerPrefs.SetFloat("EffectsVolume", 1);
		}
		if(!PlayerPrefs.HasKey("EffectsMuted")){
			PlayerPrefs.SetInt("EffectsMuted", 0);
		}
		if(!PlayerPrefs.HasKey("FullScreen")){
			PlayerPrefs.SetInt("FullScreen", 1);
		}
	}


	void LoadSettings(){
		Debug.Log(PlayerPrefs.GetInt("MusicMuted"));
		SetMusicMute(PlayerPrefs.GetInt("MusicMuted") != 0);
		SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
		SetEffectsMute(PlayerPrefs.GetInt("EffectsMuted") != 0);
		SetEffectsVolume(PlayerPrefs.GetFloat("EffectsVolume"));
		SetFullScreen(PlayerPrefs.GetInt("FullScreen") == 1);
	}

	void SaveSettings(){
		PlayerPrefs.SetFloat("MusicVolume", GetMusicVolume());
		PlayerPrefs.SetInt("MusicMuted", Convert.ToInt32(IsMusicMuted()));
		PlayerPrefs.SetFloat("EffectsVolume", GetEffectsVolume());
		PlayerPrefs.SetInt("EffectsMuted", Convert.ToInt32(IsEffectsMuted()));
		PlayerPrefs.SetInt("FullScreen", Convert.ToInt32(IsFullScreen()));
	}



#region Music
	bool _mutedMusic;
	public void SetMusicMute(bool mute){
		_mutedMusic = mute;
		foreach( GameObject go in GameObject.FindGameObjectsWithTag("Music")){
			AudioSource audio = go.GetComponent<AudioSource>();
			if(audio){
				audio.mute = _mutedMusic;
			}
		}
		PlayerPrefs.SetInt("MusicMuted", Convert.ToInt32(IsMusicMuted()));
	}
	public bool IsMusicMuted(){
		return PlayerPrefs.GetInt("MusicMuted") == 1;
	}
	public void SetMusicVolume(float volume){
		AudioListener.volume = volume;
		PlayerPrefs.SetFloat("MusicVolume", GetMusicVolume());
	}
	public float GetMusicVolume(){
		return PlayerPrefs.GetFloat("MusicVolume");
	}
#endregion

#region Sound Effects
	float _effectsVolume = 1f;
	bool _mutedEffects;

	public void SetEffectsMute(bool mute){
		_mutedEffects = mute;
		foreach( GameObject go in GameObject.FindGameObjectsWithTag("SoundEffect")){
			foreach(AudioSource audio in go.GetComponents<AudioSource>()){
				audio.mute = _mutedEffects;
			}
		}
		PlayerPrefs.SetInt("EffectsMuted", IsEffectsMuted()? 1 : 0);
	}
	public bool IsEffectsMuted(){
		Debug.Log("em " + PlayerPrefs.GetInt("EffectsMuted"));
		return Convert.ToBoolean(PlayerPrefs.GetInt("EffectsMuted"));

	}
	public void SetEffectsVolume(float volume){
		_effectsVolume = volume;
		foreach( GameObject go in GameObject.FindGameObjectsWithTag("SoundEffect")){
			foreach(AudioSource audio in go.GetComponents<AudioSource>()){
				audio.volume = _effectsVolume;
			}
		}
		PlayerPrefs.SetFloat("EffectsVolume", GetEffectsVolume());
	}
	public float GetEffectsVolume(){
		return PlayerPrefs.GetFloat("EffectsVolume");
	}
	#endregion


	#region Screen
	public void SetFullScreen(bool foolScreen) {
		Screen.fullScreen = foolScreen;

		PlayerPrefs.SetInt("FullScreen", Convert.ToInt32(IsFullScreen()));
	}
	public bool IsFullScreen(){
		return PlayerPrefs.GetInt("FullScreen") == 1;
	}
	#endregion

}
