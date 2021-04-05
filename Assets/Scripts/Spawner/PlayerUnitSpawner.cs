using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class PlayerUnitSpawner : MonoBehaviour
{
    [SerializeField] protected UnitSpawner _unitSpawner;
    [SerializeField] protected Team _team;

    [SerializeField] private Transform _tankSpawnPoint;
    [SerializeField] private Transform _soldierSpawnPoint;

    private int _soldierCost = 100;
    private int _tankCost = 400;
    private int _workerCost = 200;

    private static string NOT_ENOUGH_MONEY_STRING = "Not enough money to spawn unit.";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnSoldier();
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SpawnTank();
        }
    }
    
    public virtual void SpawnTank()
    {
        bool success = PlayerMoneyManager.Instance.Remove(_tankCost);
        if (!success)
        {
            UIManager.Instance.ShowMessagePopup(NOT_ENOUGH_MONEY_STRING);
            return;
        }
        Unit unit = _unitSpawner.SpawnTank(_team, _tankSpawnPoint.position);
        PlayerUnitsManager.Instance.Register(unit);
    }

    public virtual void SpawnSoldier()
    {
        bool success = PlayerMoneyManager.Instance.Remove(_soldierCost);
        if (!success)
        {
            UIManager.Instance.ShowMessagePopup(NOT_ENOUGH_MONEY_STRING);
            return;
        }
        Unit unit = _unitSpawner.SpawnSoldier(_team, _soldierSpawnPoint.position);
        PlayerUnitsManager.Instance.Register(unit);
    }
    
    public void SpawnWorker()
    {
        bool success = PlayerMoneyManager.Instance.Remove(_workerCost);
        if (!success)
        {
            UIManager.Instance.ShowMessagePopup(NOT_ENOUGH_MONEY_STRING);
            return;
        }
        PlayerMoneyManager.Instance.AddWorker();
    }
}