using UnityEngine;

public class ItemObj : RaceObj
{
    public MeshRenderer gOM;
    public override void DisableObj()
    {
        setUp.DisableObj(this);
    }
    public void SetMaterial(Material material)
    {
        gOM.material = material;
    }
}
