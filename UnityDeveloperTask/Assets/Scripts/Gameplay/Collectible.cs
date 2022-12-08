using UnityEngine;

public class Collectible : MonoBehaviour
{
    // private
    Collider Collider;

    // public
    public CollectibleScriptables CollectibleType;
    public string Type {get; set;}
    public Renderer rd;

    // Start is called before the first frame update
    void Start()
    {
        Type = CollectibleType.CollectibleName;
        Collider = GetComponent<Collider>();
    }

    // Collectibles can be collected by clicking on them and by player triggering collision
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            UpdateAndTriggerSpawn();
        }
    }

    void OnMouseDown() 
    {
        UpdateAndTriggerSpawn();
    }

    void UpdateAndTriggerSpawn()
    {
        GameManager.Instance.CollectibleUpdateUI?.RaiseEventWithCollectible(this);
        GameManager.Instance.PlayMunchSound();
        GameManager.Instance.OnSpawnCollectible?.Invoke();
        Destroy(this.gameObject);
    }
}
