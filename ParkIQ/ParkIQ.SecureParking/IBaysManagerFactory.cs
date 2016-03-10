using JetBrains.Annotations;
using Selkie.Windsor;

namespace ParkIQ.SecureParking
{
    public interface IBaysManagerFactory : ITypedFactory
    {
        IBaysManager Create(int numberOfBays);
        void Release([NotNull] IBaysManager baysManager);
    }
}