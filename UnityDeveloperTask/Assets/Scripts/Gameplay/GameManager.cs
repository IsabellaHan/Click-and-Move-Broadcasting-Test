using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
     // Private
    AudioClip Clip;
    AudioSource source;
    // Public
    public static GameManager Instance { get; private set; }
    public PlayerController PlayerController;
    public EventChannel CollectibleUpdateUI;
    public int AppleScore = 0;
    public int CakeScore = 0;
    public int SodaScore = 0;
    public UnityAction<Collectible> OnUpdatingCollectibles;
    public UnityAction OnSpawnCollectible;
    public Collectible CurrentCollectible;
    public OffScreenIndicator OffScreenIndicator;

    void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    void Start()
    {
        CollectibleUpdateUI.OnEventRaisedWithCollectible += DoUpdateCollectibleScore;
        OffScreenIndicator = Camera.main.GetComponent<OffScreenIndicator>();

        source = GetComponent<AudioSource>();
        Clip = source.clip;
    }

    void DoUpdateCollectibleScore(Collectible col)
    {
        switch(col.CollectibleType.CollectibleName)
        {
            case "Apple":
                AppleScore = AppleScore + col.CollectibleType.Value;
                break;
            case "Soda":
                SodaScore = SodaScore + col.CollectibleType.Value;
                break;
            case "Cake":
                CakeScore = CakeScore + col.CollectibleType.Value;
                break;
        }

        OnUpdatingCollectibles?.Invoke(col);
    }

    public void SetUpCollectibles()
    {
        OffScreenIndicator?.SetNewCollectible();
    }

    public void PlayMunchSound()
    {
        source.PlayOneShot(Clip);
    }
}
