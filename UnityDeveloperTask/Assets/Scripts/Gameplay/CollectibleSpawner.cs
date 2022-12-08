using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    // private
    [SerializeField]
    GameObject[] collectibleObjs;
    Vector3 randomSpawnPos;
    // Start is called before the first frame update
    void Start()
    {
        DoSpawnNewCollectibleRandomly();
        GameManager.Instance.OnSpawnCollectible += DoSpawnNewCollectibleRandomly;
    }

    void DoSpawnNewCollectibleRandomly()
    {
        randomSpawnPos = new Vector3(Random.Range(-20, 25), 1, Random.Range(-20,25));
        GameObject currentObj;
        currentObj = Instantiate (collectibleObjs[UnityEngine.Random.Range(0,3)], randomSpawnPos, Quaternion.identity);
        GameManager.Instance.CurrentCollectible = currentObj.GetComponent<Collectible>();
        GameManager.Instance.SetUpCollectibles();
    }

}
