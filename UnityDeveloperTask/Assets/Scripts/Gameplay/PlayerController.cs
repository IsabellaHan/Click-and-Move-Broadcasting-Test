using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    // Public 
    public EventChannel MoveAndClickChannel;
    public EventChannel CollectibleUpdateUI;
    public EventChannel SpeedUpdateUI;
    public NavMeshAgent agent {get; set;}
    public int AppleScore {get; set;}

    // Start is called before the first frame update
    void Start()
    {
        MoveAndClickChannel.OnEventRaised += DoMove;
        agent = GetComponent<NavMeshAgent>();
        SpeedUpdateUI?.RaiseEvent();
    }

    void DoMove()
    {
        RaycastHit hit;
                
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) 
        {
            agent.destination = hit.point;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        GameObject collidedObj;
        Collectible colItem;
        if(col.gameObject.tag == "Collectible")
        {
            collidedObj = col.gameObject;
            colItem = collidedObj.GetComponent<Collectible>();
            GameManager.Instance.OnSpawnCollectible?.Invoke();
        }
    }

    public void IncreaseSpeed()
    {
        agent.speed++;
        if(agent.speed >= 10)
        {
            agent.speed = 10;
        }
        SpeedUpdateUI?.RaiseEvent();
    }

    public void DecreaseSpeed()
    {
        agent.speed--;
        if(agent.speed <= 0)
        {
            agent.speed = 0;
        }
        SpeedUpdateUI?.RaiseEvent();
    }
}
