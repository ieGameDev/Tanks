namespace Infrastructure.DI
{
    public class DIContainer
    {
        private static DIContainer _instance;
        public static DIContainer Container => _instance ?? (_instance = new DIContainer());

        public void RegisterSingle<TService>(TService implementation) where TService : IService =>
            Implementation<TService>.ServiceInstance = implementation;

        public TService Single<TService>() where TService : IService =>
            Implementation<TService>.ServiceInstance;

        private static class Implementation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}
