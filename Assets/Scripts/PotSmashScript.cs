using UnityEngine;

public class PotSmashScript : MonoBehaviour
{
    //Variables
    public GameObject pot;
    public GameObject shards;
    public GameObject potShatterEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pot = GameObject.Find("pot");
        shards = GameObject.Find("shards");
        potShatterEffect = GameObject.Find("potShatterEffect");

        if (pot != null)
            pot.SetActive(true);
        if (shards != null)
            shards.SetActive(false);
        if (potShatterEffect != null)
            potShatterEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        if (pot != null)
            pot.SetActive(false);
        if (shards != null)
            shards.SetActive(true);
        if (potShatterEffect != null)
            potShatterEffect.SetActive(true);
    }
}
