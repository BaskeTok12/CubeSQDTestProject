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
    
        private const string MasterVolume = "MasterVolume";

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
          
        }
    
        private void PlaySound()
        {
            //effectsSource.PlayOneShot();
        }
    }
}
