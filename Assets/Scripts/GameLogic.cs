using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    Vector2 characterPositionInPercent;
    
    Vector2 characterVelocityInPercent;
    
    const float CharacterSpeed = 0.25f;


    void Start()
    {
        NetworkedServerProcessing.SetGameLogic(this);
    }

    void Update()
    {
        characterPositionInPercent += (characterVelocityInPercent * Time.deltaTime);
    }

    public void updateDirectionalInput(int d, int clientId)
    {
        characterVelocityInPercent = Vector2.zero;

        if (d == KeyBoardInputDirections.UpRight)
        {
            characterVelocityInPercent.x = CharacterSpeed;
            characterVelocityInPercent.y = CharacterSpeed;
        }
        else if (d == KeyBoardInputDirections.UpLeft)
        {
                characterVelocityInPercent.x = -CharacterSpeed;
            characterVelocityInPercent.y = CharacterSpeed;
        }
        else if (d == KeyBoardInputDirections.DownRight)
        {
            characterVelocityInPercent.x = CharacterSpeed;
            characterVelocityInPercent.y = -CharacterSpeed;
        }
        else if (d == KeyBoardInputDirections.DownLeft)
        {
            characterVelocityInPercent.x = -CharacterSpeed;
            characterVelocityInPercent.y = -CharacterSpeed;
        }
        else if (d == KeyBoardInputDirections.Right)
        {
            characterVelocityInPercent.x = CharacterSpeed;
        }
        else if (d == KeyBoardInputDirections.Left)
        {
                characterVelocityInPercent.x = -CharacterSpeed;
        }
        else if (d == KeyBoardInputDirections.Up)
        {
            characterVelocityInPercent.y = CharacterSpeed;
        }
        else if (d == KeyBoardInputDirections.Down)
        {
            characterVelocityInPercent.y = -CharacterSpeed;
        }
        else if (d == KeyBoardInputDirections.NoPress)
        {
           characterVelocityInPercent = Vector2.zero;
        }

        NetworkedServerProcessing.SendMessageToClient(ServerToClientSignifiers.VelocityAndPosition + "," +characterVelocityInPercent.x + "," + characterVelocityInPercent.y + "," + characterPositionInPercent.x + "," + characterPositionInPercent.y, clientId);
    }
}





