using Assets.Scripts.Infrastructure.DI;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.AssetsManager
{
    public interface IAssetsProvider : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 initialPoint);
    }
}