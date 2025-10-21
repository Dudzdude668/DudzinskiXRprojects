using UnityEngine;

public enum FeatureUsage
{
    Once, //use once
    Toggle, //if you want to use the feature more than once
}
public class CoreFeatures : MonoBehaviour
{
    /* 
     * Property - Common way to access code that exsists outside of this class
     * Can create Public variable and acess them that way or can use properties
     * Properties ENCAPSULATES variables as fields
     * GET Accessor (READ) - return encapsulated variable values
     * SET Accessor (WRITING) - allocates new vales to the property fields
     * PROPERTY values use PascalCase
     */ 

    public bool AudioSFXSourceCreated { get; set; }

    [field: SerializeField]
    public AudioClip AudioClipOnStart { get; set; }
    
    [field: SerializeField]
    public AudioClip AudioClipOnEnd { get; set; }

    private AudioSource audioSource;

    public FeatureUsage featureUsage = FeatureUsage.Once;

    protected virtual void Awake()
    {
        MakeSFXAudioSource();
    }

    public void MakeSFXAudioSource()
    {
        audioSource = GetComponent<AudioSource>();

        //if this is equal to null, create it here

        if (audioSource == null)
        {
            audioSource = gameObject.GetComponent<AudioSource>();
        }

        //whether it null or not, we still need to make sure this is true
        // On Awake creat this audiosource

        AudioSFXSourceCreated = true;
    }
}
