using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;
using SiraUtil;

namespace EnableFPFC.Installer
{
    public class FPFCGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Container.BindInterfacesAndSelfTo<EnableFPFCController>().FromNewComponentOnNewGameObject(nameof(EnableFPFCController)).AsCached().NonLazy();
        }
    }
}
