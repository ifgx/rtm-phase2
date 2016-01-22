using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour, AudioProcessor.AudioCallbacks
{
    public int width;
    public int height;
    public Color backgroundColor = new Color(0,0,0,0);
	public Color waveformColor = Color.black;
    public Color cursorColor = Color.green;
    public int size = 2048;
	public static float songAmplitude = 0;

    Color[] blank;
    Texture2D texture;
	Texture2D textureCursor;
    float[] samples;
    AudioSource audioSource;
    AudioSource audioSourceHB;
    AudioClip clip;
    Light sceneLight;
    public GameObject image;
    private RawImage img;

	public GameObject cursor;
	private RawImage cursorImg;

	private string musicName;

    // Use this for initialization
    void Start () {
        
    }

	public void SetMusicName(string name){
		musicName = name;
	}

	public void Init(){
		if (musicName != null) {
            audioSourceHB = gameObject.AddComponent<AudioSource>();
            audioSourceHB.clip = Resources.Load("Musics/Hearbeat") as AudioClip;
            audioSourceHB.volume = 0;
            audioSourceHB.Play();

            //audioSource = GetComponent<AudioSource>();
            audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
            samples = new float[size];

            //clip = Resources.Load ("Musics/" + musicName, typeof(AudioClip)) as AudioClip;
            //USING WWW to load the audioclip in root/Musics
            
            string path = "file://" + Application.dataPath + "/../Musics/"+musicName+".wav";
			//Debug.Log ("music : " + path);
			WWW www = new WWW(path);
            while (!www.isDone) {
				//Debug.Log ("loading music ...");
			}


            clip = www.GetAudioClip(false);
            
            audioSource.clip = clip;

            sceneLight = FindObjectOfType<Light>();
            AudioProcessor processor = FindObjectOfType<AudioProcessor>();
            processor.init();
            processor.start = true;
            processor.addAudioCallback(this);
            // create the texture and assign to the guiTexture:
            img = (RawImage) image.GetComponent<RawImage>();
			cursorImg = (RawImage) cursor.GetComponent<RawImage>();

			width = (int) GetComponent<RectTransform>().rect.width;
			height = (int)GetComponent<RectTransform>().rect.height;
			
			texture = new Texture2D(width, height);
			textureCursor = new Texture2D(width, height);
			img.texture = texture;
			cursorImg.texture = textureCursor;

			// create a 'blank screen' image
			blank = new Color[width * height];
			
			for (var i = 0; i < blank.Length; i++)
			{
				blank[i] = backgroundColor;
			}
			
			//IGNORED (BV) useless soundwave
			//textureCursor.SetPixels(blank, 0);
			//textureCursor.Apply();
			// refresh the display each 100mS
<<<<<<< HEAD
			//GetWaveForm ();
            createMusicalLights();
			//StartCoroutine (UpdateWaveForm ());
=======
			GetWaveForm ();
			StartCoroutine (UpdateWaveForm ());
>>>>>>> d53d56bbe75e7a133ad8316093b2a9f697f25645
		}
	}

    public void onOnbeatDetected()
    {
        //Debug.Log("Beat!!!");
        
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
        int sizeWaveform = audioSource.clip.samples;
        int secondes = sizeWaveform / audioSource.clip.frequency;
        int pas = width / secondes;
        int i,j;
		int currentCount = 1;
        while (true)
        {
			if(audioSource.isPlaying){
                float healthPointratio = GameModel.HerosInGame[0].HealthPoint / GameModel.HerosInGame[0].MaxHealthPoint;
                audioSource.volume = healthPointratio / 2;
                audioSourceHB.volume = 1 - healthPointratio;
                if(healthPointratio < 0.4f)
                {
                    audioSourceHB.pitch = 1.2f;
                }
                else
                {
                    audioSourceHB.pitch = 1;
                }
                
                textureCursor.SetPixels(blank, 0);
	            for (i = 1; i < height; i++) //sizeWaveform
	            {
					for (j = pas * (currentCount-1); j <= (pas * currentCount)+10; j++) //sizeWaveform
					{
	                textureCursor.SetPixel(j, i, cursorColor);
					}
	            }
				textureCursor.Apply();
				currentCount = currentCount + 1;

				audioSource.GetOutputData(samples, 0);
				int k;
				float sum = 0;
				float moyenne = 0;
				float min = float.MaxValue;
				float max = float.MinValue;
				
				// draw the waveform
				for (k = 0; k < size; k++)
				{
					if (samples[k] > max)
					{
						max = samples[k];
					}
					if (samples[k] < min)
					{
						min = samples[k];
					}
					sum = sum + samples[k];
				}

				songAmplitude = max;
			}
            yield return new WaitForSeconds(1.0f);
        }
    }

    void GetWaveForm()
    {
        int sizeWaveform = audioSource.clip.samples;
        float[] samplesWaveForm = new float[sizeWaveform+1];
        //Debug.Log("sizeWaveForm:" + sizeWaveform);
        audioSource.clip.GetData(samplesWaveForm, sizeWaveform/4);

        //Debug.Log("fq:"+audioSource.clip.frequency+" / sp:"+ sizeWaveform + "="+ sizeWaveform / audioSource.clip.frequency+"s calculées au début");

        texture.SetPixels(blank, 0);
        int i;
        for (i=  1; i< sizeWaveform; i++) //sizeWaveform
        {
            //texture.SetPixel((width * i) / sizeWaveform, (int)(height * (samplesWaveForm[i] + 1f) / 2), waveformColor);
            texture.SetPixel((width * i)/i, (int)(height * (samplesWaveForm[i] + 1f) / 2), waveformColor);
        }
        texture.Apply();
    }

    void GetCurWave()
    {
        // clear the texture
        texture.SetPixels(blank, 0);

        // get samples from channel 0 (left)
        audioSource.GetOutputData(samples, 0);

        // draw the waveform
        for (var i = 0; i < size; i++)
        {
            texture.SetPixel((int)((width * i) / size), (int)(height * (samples[i] + 1f) / 2), waveformColor);
        }
        // upload to the graphics card
        texture.Apply();
    }
    // Update is called once per frame
    void Update () {
	
	}
}
