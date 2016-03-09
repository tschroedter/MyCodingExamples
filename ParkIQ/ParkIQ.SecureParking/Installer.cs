using System.Diagnostics.CodeAnalysis;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ParkIQ.SecureParking.Vehicles;
using Selkie.Windsor;

namespace ParkIQ.SecureParking
{
    [ExcludeFromCodeCoverage]
    public class Installer : BaseInstaller <Installer>
    {
        protected override void InstallComponents(IWindsorContainer container,
                                                  IConfigurationStore store)
        {
            base.InstallComponents(container,
                                   store);

            container.Register(
                               Classes.FromThisAssembly()
                                      .BasedOn <IVehicle>()
                                      .WithServiceFromInterface(typeof ( IVehicle ))
                                      .Configure(c => c.LifeStyle.Is(LifestyleType.Transient)));
        }

        public override string GetPrefixOfDllsToInstall()
        {
            return "ParkIQ.";
        }
    }
}