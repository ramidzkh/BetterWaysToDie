using System.Diagnostics;
using SharpILMixins.Annotations;
using SharpILMixins.Annotations.Inject;

namespace BetterWaysToDie.Mixins.Gui
{
    [Mixin(typeof(XUiC_InGameDebugMenu))]
    public class InGameDebugMenuMixin
    {
        [Inject(XUiC_InGameDebugMenuTargets.Methods.BtnSuicide_Controller_OnPress, AtLocation.Head)]
        [Unique]
        private void OnSuicideButtonPress()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://lifeline.org.au/"
            });
        }
    }
}
