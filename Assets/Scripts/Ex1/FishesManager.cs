using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishesManager : MonoBehaviour
{
    [SerializeField]
    GameObject fishPrefab;

    [SerializeField]
    GameObject boxVolumeGO;

    [SerializeField]
    private float boxRadius = 10;

    [SerializeField]
    public int m_nb_follower_fishes_spawned = 10;
    [SerializeField]
    public int m_nb_leader_fishes_spawned = 3;
        
    [SerializeField]
    public int m_nb_boids_spawned = 15;

    // Start is called before the first frame update
    void Start()
    {
        boxVolumeGO.transform.localScale = (boxRadius) * Vector3.one * 2;
        for(int i = 0; i<m_nb_follower_fishes_spawned; i++){
           SpawnFish(typeof(FollowerFish));
        }
        for(int i = 0; i<m_nb_leader_fishes_spawned; i++){
           SpawnFish(typeof(LeaderFish));
        }
        for(int i = 0; i<m_nb_boids_spawned; i++){
           SpawnFish(typeof(Boid));
        }
    }
    private void SpawnFish(System.Type fishType){
         var position = new Vector3(Random.Range(-boxRadius+1, boxRadius-1),Random.Range(-boxRadius+1, boxRadius-1),Random.Range(-boxRadius+1, boxRadius-1));
            GameObject fish = Instantiate(fishPrefab,position, new Quaternion(Random.Range(-180,180),Random.Range(-180,180),Random.Range(-180,180),Random.Range(-180,180)),transform);
            fish.AddComponent(fishType);
            initFish(fish);
    }
    private void initFish(GameObject _fish){
        AFish ourFish = _fish.GetComponent<AFish>();
        ourFish.InitFish(boxRadius);
    }
    private void OnValidate() {
        boxVolumeGO.transform.localScale = (boxRadius) * Vector3.one * 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
