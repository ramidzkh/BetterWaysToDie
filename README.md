# Better Ways To Die

Modding 7 Days to Die

## Finding libraries

Copy the dependencies required by `Libraries/README.md`

## Setup

1. Install [`SharpILMixins.Processor`](https://www.nuget.org/packages/SharpILMixins.Processor/) (`dotnet tool install --global SharpILMixins.Processor`)
2. Run `dotnet build`
3. Open a command prompt in `BetterWaysToDie/bin/Debug/net40`
4. Run `sharpilmixins -t . -m BetterWaysToDie.dll --mixin-handler-name bwtd`
5. The generated `Assembly-CSharp.dll` should be suitable to replace the original from 7 Days to Die
