using System;
using System.Collections;
using UnityEngine;

public static class PlayerInvoker
{
    // now an private static variable, to not let other scripts access to it, while returing it with minimal performance lose.
    internal static void MovePlayer(GameObject player, float vector)
    {
        if (player == null || vector == 0) return;
        PlayerHandler playerHandler = GetPlayerHandler(player);
        
        if (TryCheckForPlayerPositionAndReturnNewPosition(
            player,
            vector
            * playerHandler.PlayerSpeed
            * Time.deltaTime,
            out float nextPosition
        ))
        {
            player.transform.position = new Vector3(
                nextPosition,
                player.transform.position.y,
                player.transform.position.z
                );
        }
    }
    internal static bool CheckIfCanControlPlayer(GameObject player)
    {
        if (player == null) return false;
        PlayerHandler playerHandler = GetPlayerHandler(player);
        if (GameManager.instance.CurrentGameState != GameStates.Playing || playerHandler.Health <= 0)
        {
            return false;
        }
        return true;
    }
    internal static void ShootFromPlayer(GameObject playerObject)
    {
        PlayerHandler playerHandler = GetPlayerHandler(playerObject);
        ProjectileManager.Instance.Shoot(
            playerObject.transform.position
            + new Vector3(
            0,
            playerObject.transform.localScale.y,
            0),
            playerHandler.projectileData
        );
    }
    public static PlayerHandler GetPlayerHandler(GameObject playerObject)
    {
        if (playerObject != null
        && playerObject.TryGetComponent(out PlayerHandler handler))
        {
            return handler;
        }
        return null;
    }
    public static PlayerHandler GetPlayerHandler(string playerTag)
    {
        GameObject potentialObject = null;

        foreach (GameObject go in GameObject.FindGameObjectsWithTag(playerTag))
        {

            if (go.TryGetComponent(out PlayerHandler _))
            {

                potentialObject = go;
                break;
            }
        }

        if (potentialObject != null && potentialObject.TryGetComponent(out PlayerHandler handler))
        {

            return handler;
        }

        return null;
    }
    private static bool TryCheckForPlayerPositionAndReturnNewPosition(GameObject player, float xDirectionSpeed, out float result)
    {
        Camera _camera = Camera.main;
        result = 0;
        if (_camera == null) return false;
        float limitX = _camera.ScreenToWorldPoint(new Vector3(Screen.width, 0)).x - player.transform.lossyScale.x;
        float playerXPosition = player.transform.position.x;
        if (playerXPosition + xDirectionSpeed >= limitX || playerXPosition + xDirectionSpeed <= -limitX)
        {
            result = Mathf.Clamp(playerXPosition + xDirectionSpeed, -limitX, limitX);
            return true;
        }
        else
        {
            result = playerXPosition + xDirectionSpeed;
            return true;
        }
    }
}
