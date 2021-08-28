using System.Diagnostics;
using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;
using SharpILMixins.Annotations.Parameters;

namespace BetterWaysToDie.Mixins.Gui
{
    [Mixin(typeof(XUiC_InGameDebugMenu))]
    public class InGameDebugMenuMixin
    {
        [Inject(XUiC_InGameDebugMenuTargets.Methods.BtnSuicide_Controller_OnPress, AtLocation.Head)]
        [Unique]
        private void OnSuicideButtonPress([InjectCancelParam] out bool cancel)
        {
            cancel = Process.Start(new ProcessStartInfo
            {
                FileName = "https://lifeline.org.au/"
            })?.ExitCode == 0;
        }
    }
}
