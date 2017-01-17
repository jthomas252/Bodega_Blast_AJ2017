using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace LAJ_2017 {
    public class SoundHandler : MonoBehaviour {
        public enum Variant {
            Normal,
            Angry,
            Insane,
            Scared,
            Happy
        }

        [System.Serializable]
        public struct MusicTrack {
            public AudioClip clip;
            public string    name; 
        }

        [System.Serializable]
        public struct SoundEffect {
            public AudioClip clip;
            public Variant   variant;
            public string    name; 
        }

        public MusicTrack[]  musicTracks;
        public SoundEffect[] soundEffects;

        private Dictionary<string, List<AudioClip>>                      musicDictionary; 
        private Dictionary<string, Dictionary<Variant, List<AudioClip>>> soundDictionary; 
        private AudioSource                                              musicSource; 
        private AudioSource                                              soundSourceGlobal; 

        public void Awake() {
            musicDictionary = new Dictionary<string,List<AudioClip>>(); 
            for (int i = 0; i < musicTracks.Length; ++i) {
                if (!musicDictionary.ContainsKey(musicTracks[i].name)) musicDictionary.Add(musicTracks[i].name, new List<AudioClip>()); 
                musicDictionary[musicTracks[i].name].Add(musicTracks[i].clip);
            }

            soundDictionary = new Dictionary<string,Dictionary<Variant,List<AudioClip>>>(); 
            for (int i = 0; i < soundEffects.Length; ++i) {
                if (!soundDictionary.ContainsKey(soundEffects[i].name)) {
                    soundDictionary.Add(soundEffects[i].name, new Dictionary<Variant, List<AudioClip>>());
                    soundDictionary[soundEffects[i].name][soundEffects[i].variant] = new List<AudioClip>();
                }
                soundDictionary[soundEffects[i].name][soundEffects[i].variant].Add(soundEffects[i].clip);
            }

            AudioSource[] sources = GetComponents<AudioSource>();
            if (sources.Length >= 1) musicSource       = sources[0];
            if (sources.Length >= 2) soundSourceGlobal = sources[1]; 
        }

        public void PlayMusic(string name) {
            if (musicDictionary.ContainsKey(name)) {
                int rand = Mathf.RoundToInt(Random.Range(0, musicDictionary[name].Count));
                musicSource.clip = musicDictionary[name][rand];
                musicSource.Play();
            }
        }

        public void PlaySound(string name, AudioSource source = null, Variant variant = Variant.Normal) {
            if (soundDictionary.ContainsKey(name)) {
                //Select a random instance of that sound
                int rand = Mathf.RoundToInt(Random.Range(0,soundDictionary[name][variant].Count));

                Debug.Log(name);
                if (source != null) {
                    source.PlayOneShot(soundDictionary[name][variant][rand]);
                } else if (soundSourceGlobal != null) {
                    soundSourceGlobal.PlayOneShot(soundDictionary[name][variant][rand]); 
                }
            } else {
                Debug.LogWarning("Attempted to play sound " + name + " but it is not set.");
            }
        }
    }
}