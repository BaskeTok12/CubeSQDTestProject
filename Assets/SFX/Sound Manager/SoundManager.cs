using Game_Manager;
using UnityEngine;
using UnityEngine.Audio;

namespace SFX.Sound_Manager
{
    public class SoundManager : MonoBehaviour
    {
        [Header("Mixer")] 
        [SerializeField] private AudioMixerGroup mainMixer;
        [Header("Sources")]
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource effectsSource;
        [Header("Sounds")] 
        [SerializeField] private AudioClip playerDeathSound;


        private void OnEnable()
        {
            GameManager.OnFault += PlayPlayerDeathSound;
        }

        private void OnDisable()
        {
            GameManager.OnFault -= PlayPlayerDeathSound;
        }
    
        private void PlayPlayerDeathSound()
        {
            effectsSource.PlayOneShot(playerDeathSound);
        }
    }
}
