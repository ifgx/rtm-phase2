using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour, AudioProcessor.AudioCallbacks
{
    public static float songAmplitude = 0.1f;
    AudioSource audioSource;
    AudioSource audioSourceHB;
    AudioSource noiseSource;
    AudioClip clip;
    AudioClip heroCoup;
    AudioClip fireball;
    AudioClip heroShield;
    AudioClip heroSword;
	AudioClip heroWood1,heroWood2;
    AudioClip potion;
    AudioClip heal;

    private string musicName;

    // Use this for initialization
    void Start () {
        
    }

	public void SetMusicName(string name){
		musicName = name;
	}

	public void Init(){
        noiseSource = gameObject.AddComponent<AudioSource>();
        heroCoup = Resources.Load("sounds/aie") as AudioClip;
        //heroShield = Resources.Load("sounds/aie") as AudioClip;
        heroSword = Resources.Load("sounds/epee") as AudioClip;
        fireball = Resources.Load("sounds/fireball") as AudioClip;
		heroWood1 = Resources.Load("sounds/coupBaton") as AudioClip;
		heroWood2 = Resources.Load("sounds/impactbaton") as AudioClip;
        potion = Resources.Load("sounds/potion") as AudioClip;
        heal = Resources.Load("sounds/priere") as AudioClip;

        if (musicName != null) {

            audioSourceHB = gameObject.AddComponent<AudioSource>();
            audioSourceHB.clip = Resources.Load("Musics/Hearbeat") as AudioClip;
            audioSourceHB.volume = 0;
            audioSourceHB.Play();
            //audioSource = GetComponent<AudioSource>();
            audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
            
            string path = "file://" + Application.dataPath + "/../Musics/"+musicName+".wav";
			//Debug.Log ("music : " + path);
			WWW www = new WWW(path);
            while (!www.isDone) {
				//Debug.Log ("loading music ...");
			}

            clip = www.GetAudioClip(false);
            audioSource.volume = 0.5f;
            audioSource.clip = clip;
            
            AudioProcessor processor = FindObjectOfType<AudioProcessor>();
            if (processor != null)
            {
                processor.init();
                processor.start = true;
                processor.addAudioCallback(this);
            }
			
			StartCoroutine (UpdateWaveForm ());
		}
	}
    public void playHeroHurtSound()
    {
        noiseSource.volume = 0.6f;
        noiseSource.PlayOneShot(heroCoup);
    }
    public void playFireballSound()
    {
        noiseSource.volume = 1.0f;
        noiseSource.PlayOneShot(fireball);
    }
    public void playHeroShieldSound()
    {
        noiseSource.volume = 0.5f;
        noiseSource.PlayOneShot(heroShield);
    }
    public void playHeroSwordSound()
    {
        noiseSource.volume = 1.0f;
        noiseSource.PlayOneShot(heroSword);
    }
	public void playHeroWoodWeaponSound(){
		noiseSource.volume = 0.6f;
		noiseSource.PlayOneShot(heroWood2);
	}
    public void playPotionSound()
    {
        noiseSource.volume = 1.0f;
        noiseSource.PlayOneShot(potion);
    }
    public void playHealSound()
    {
        if (!noiseSource.isPlaying)
        {
            noiseSource.volume = 0.6f;
            noiseSource.PlayOneShot(heal);
        }
    }
    public void onOnbeatDetected()
    {

    }
    public void onSpectrum(float[] spectrum)
    {
        //The spectrum is logarithmically averaged
        //to 12 bands

        for (int i = 0; i < spectrum.Length; ++i)
        {
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end = new Vector3(i, spectrum[i], 0);
            Debug.DrawLine(start, end);
        }
    }
    public void Pause(){
		audioSource.Pause ();
        audioSourceHB.Pause();
    }
	public void Play(){
        if (!audioSourceHB.isPlaying)
        {
            audioSourceHB.Play();
        }
        if (!audioSource.isPlaying){
		audioSource.Play ();
        }
	}

    IEnumerator UpdateWaveForm()
    {
        while (true)
        {
			if(audioSource.isPlaying){
                float healthPointratio = GameModel.HerosInGame[0].HealthPoint / GameModel.HerosInGame[0].MaxHealthPoint;
                audioSource.volume = Mathf.Min(healthPointratio / 2, 0.5f);

                audioSourceHB.volume = 1 - healthPointratio;
                if(healthPointratio < 0.4f)
                {
                    audioSourceHB.pitch = 1.2f;
                }
                else
                {
                    audioSourceHB.pitch = 1;
                }
                
			}
            yield return new WaitForSeconds(1.0f);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
