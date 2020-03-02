using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompetitionManager : MonoBehaviour
{//as of now this script isn't really used at all
 //in the pirate ship example, this script spawned all the "players" and assigned each their AI
 //However, in our design I think we'll be using this to keep track of all the players individual stats and states.
 //either way, at the moment it does nothing, but it will be important later//
    public GameObject unitAvatarPrefab = null;
    public StatControl[] PlayerStats; //array with all player current stats.
    public Transform[] SpawnPoints;

    public BaseAI[] ais;


    private List<UnitController> unitAvatars = new List<UnitController>();

    // Start is called before the first frame update
    void Start()
    {

        
//        BaseAI[] aiArray = new BaseAI[] {
        //            new PlayerScript() 
        //        };
        //
        //        for (int i = 0; i < aiArray.Length; i++)
        //        {
        //            
        //            
        //            GameObject unitAvatar = Instantiate(unitAvatarPrefab, SpawnPoints[i].position, SpawnPoints[i].rotation);
        //            
        //            UnitController unitController = unitAvatar.GetComponent<UnitController>();
        //            StatControl statsController = unitAvatar.GetComponent<StatControl>();
        //            unitController.SetAI(aiArray[i]);
        //            unitAvatars.Add(unitController);
        //            
        //            
        //        }

    }

    // Update is called once per frame
    void Update()
    {
//        if (Input.GetKeyDown(KeyCode.Space)) {
//            foreach (var pirateShip in pirateShips) {
//                pirateShip.StartBattle();
//            }
//        }
        
    }
}
