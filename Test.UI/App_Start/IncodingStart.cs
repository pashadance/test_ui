using Test.UI.Controllers;

[assembly: WebActivator.PreApplicationStartMethod(
    typeof(Test.UI.App_Start.IncodingStart), "PreStart")]

namespace Test.UI.App_Start {
    
    public static class IncodingStart {
        public static void PreStart() {
            Bootstrapper.Start();
            new DispatcherController(); // init routes
        }
    }
}