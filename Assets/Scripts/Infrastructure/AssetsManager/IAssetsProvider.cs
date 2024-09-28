using Infrastructure.DI;
using UnityEngine;

namespace Infrastructure.AssetsManager
{
    public interface IAssetsProvider : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 initialPoint);
    }
}