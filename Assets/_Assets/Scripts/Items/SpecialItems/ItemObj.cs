using UnityEngine;

public class ItemObj : RaceObj
{
    public MeshRenderer gOM;
    public override void DisableObj()
    {
        setUp.DisableObj(this);
    }
    public void AddOutLine(Material material)
    {
        Material[] currentMs = gOM.materials;
        if (currentMs.Length <= 1)
        {
            Material[] newMs = new Material[currentMs.Length + 1];
            for (int i = 0; i < newMs.Length - 1; i++) newMs[i] = currentMs[i];
            newMs[newMs.Length - 1] = material;
            gOM.materials = newMs;
        }
    }
    public void RemoveOutLine()
    {
        Material[] currentMs = gOM.materials;
        if (currentMs.Length > 1)
        {
            Material[] newMs = new Material[currentMs.Length - 1];
            for (int i = 0; i < newMs.Length; i++) newMs[i] = currentMs[i];
            gOM.materials = newMs;
        }
    }
}
