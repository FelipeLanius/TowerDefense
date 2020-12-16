
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;


    private TurretBlueprint turretToBuild;
    private Node selectedTurret;

    public NodeUI nodeUI;


    public bool CanBuild { get { return turretToBuild != null; } }
    //public bool NoBuild { get { return PlayerStatus.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStatus.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build!");
                return;
        }

        PlayerStatus.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 3f);

        Debug.Log("Turret Build! Money left: " + PlayerStatus.Money);
    }

    public bool NoBuild()
    {
        if(PlayerStatus.Money < turretToBuild.cost)
        return true;
        
        else
        return false;
    }


    public void SelectNode(Node node)
    {
        if(selectedTurret == node)
        {
            DeselectNode();
            return;
        }

        selectedTurret = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedTurret = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }
}
