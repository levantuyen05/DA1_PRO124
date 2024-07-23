using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    public static Character player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject selectedCharacter = CharacterSelect.selectedCharacter;
        GameObject playerObject = Instantiate(selectedCharacter, transform.position, Quaternion.identity);
        playerObject.name = "player";
        switch (selectedCharacter.name)
        {
            case "Jack":
                player = new Jack(playerObject);
                break;
            case "Ross":
                player = new Ross(playerObject);
                break;
            case "Tasi":
                player = new Tasi(playerObject);
                break;
            case "Apollo":
                player = new Apollo(playerObject);
                break;
        }
    }

    
}
