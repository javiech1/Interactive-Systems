using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagers : MonoBehaviour
{

    public static SoundManagers Instance;
    public AudioClip shootClip;
    public AudioClip sheephitClip;
    public AudioClip sheepDroppedClip;
    private Vector3 cameraPosition;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        cameraPosition = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void PlaySound(AudioClip clip){
        AudioSource.PlayClipAtPoint(clip, cameraPosition);
    }

    public void PlayShootClip(){
        PlaySound(shootClip);
    }

    public void PlaySheepHitClip(){
        PlaySound(sheephitClip);
    }

    public void PlaySheepDroppedClip(){
        PlaySound(sheepDroppedClip);
    }
}
