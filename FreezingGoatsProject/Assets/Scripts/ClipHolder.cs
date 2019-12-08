using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipHolder : MonoBehaviour
{
    public static ClipHolder instance;
    public AudioClip jumpSound;
    public AudioClip yeetSound;

    public AudioClip cuteGoat0;
    public AudioClip cuteGoat1;
    public AudioClip cuteGoat2;
    public AudioClip cuteGoat3;

    public AudioClip normalGoat0;
    public AudioClip normalGoat1;
    public AudioClip normalGoat2;
    public AudioClip normalGoat3;
    // Start is called before the first frame update

        void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public AudioClip GetJumpSound()
    {
        return jumpSound;
    }

    public AudioClip GetYeetSound()
    {
        return yeetSound;
    }

   public  AudioClip GetCuteVoice()
    {
        float random = Random.Range(1f, 4f);
        AudioClip setClip = cuteGoat3;

if (random < 1)
        {
            setClip = cuteGoat0;
        }
else if(random <2)
        {
            setClip = cuteGoat1;
        }
else if (random < 3)
        {
            setClip = cuteGoat2;
        }
        return setClip;

    }
    public AudioClip GetNormalVoice()
    {
        float random = Random.Range(1f, 4f);
        AudioClip setClip = normalGoat3;

        if (random < 1)
        {
            setClip = normalGoat0;
        }
        else if (random < 2)
        {
            setClip = normalGoat1;
        }
        else if (random < 3)
        {
            setClip = normalGoat2;
        }
        return setClip;

    }
}
