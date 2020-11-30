
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color noBuildColor;
    public Color hoverColor;
    public Vector3 positionOffSet;

    [Header("Optional")]
    public GameObject turret;


    public Renderer rend;
    private Color startColor;

    BuildManager buildManager;
    TurretBlueprint turretBlueprint;

    
    

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if(turret != null)
        {
            Debug.Log("Can't Build There!");
            return;
        }

        buildManager.BuildTurretOn(this);
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if(buildManager.NoBuild())
            rend.material.color = noBuildColor;
        
        else
            rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public void TurretColor(TurretBlueprint turret)
    {
        turretBlueprint = turret;
    }
}
