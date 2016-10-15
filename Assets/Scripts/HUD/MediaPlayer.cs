using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MediaPlayer : MonoBehaviour
{
    private readonly Color32 disabledShuffleColor = new Color32(188, 188, 188, 255);

    public Slider progresBar;
    public Text songName;
    public Image shuffleImg;

    public AudioClip[] clips;
    public byte currentSongIndex;
    public bool wantShuffle;
    private bool isPlaying;

    public Image playImg;
    public Sprite playSprite;
    public Sprite pauseSprite;


    //Problems with OnChange on Slider. To work properly need to implement self slider.
    //public void Update()
    //{
    //    if (this.isPlaying)
    //    {
    //        this.progresBar.value = SoundManager.instance.musicSource.time;
    //    }
    //}

    public void TogglePlaying()
    {
        if (this.isPlaying)
        {
            Pause();
            this.playImg.sprite = this.playSprite;
        }
        else
        {
            Play();
            this.playImg.sprite = this.pauseSprite;
        }
    }

    public void Play()
    {
        this.isPlaying = true;
        SoundManager.instance.MusicPlay(this.clips[this.currentSongIndex]);
        this.progresBar.maxValue = this.clips[this.currentSongIndex].length;
        this.songName.text = this.clips[this.currentSongIndex].name;
    }

    public void Pause()
    {
        this.isPlaying = false;
        SoundManager.instance.musicSource.Pause();
    }

    public void Next()
    {
        if (this.wantShuffle)
        {
            byte newSongIndex;
            do
            {
                newSongIndex = (byte)Random.Range(0, this.clips.Length);
            }
            while (newSongIndex == this.currentSongIndex);

            this.currentSongIndex = newSongIndex;
        }
        else
        {
            if (this.currentSongIndex + 1 >= this.clips.Length)
            {
                this.currentSongIndex = 0;
            }
            else
            {
                this.currentSongIndex += 1;
            }
        }

        Play();
        this.progresBar.value = 0;
    }

    public void GoToTime(Slider slider)
    {
        SoundManager.instance.GoToTime(slider.value);
    }

    public void ToggleShuffle()
    {
        this.wantShuffle = !this.wantShuffle;
        if (this.wantShuffle)
        {
            this.shuffleImg.color = Color.white;
        }
        else
        {
            this.shuffleImg.color = this.disabledShuffleColor;
        }
    }
}