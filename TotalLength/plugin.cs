using Autodesk.AutoCAD.Runtime;

[assembly: ExtensionApplication(typeof(TotalLength.Plugin))]

namespace TotalLength
{
    /**
     * This class is instantiated by AutoCAD once and kept alive for the 
     * duration of the session
     */
    public class Plugin : IExtensionApplication
    {

        void IExtensionApplication.Initialize()
        {
            
        }

        void IExtensionApplication.Terminate()
        {
            
        }

    }
}
