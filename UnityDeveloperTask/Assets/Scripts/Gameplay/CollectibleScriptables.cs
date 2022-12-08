using UnityEngine;

[CreateAssetMenu(menuName = "Collectibles/Collectible")]
public class CollectibleScriptables : ScriptableObject
{
    public string CollectibleName;
    public int Value;
    public Sprite UISprite;
}
