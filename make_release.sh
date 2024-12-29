rm -rf obj
rm -rf bin

dotnet build RF5StackChopSmash.csproj -f net6.0 -c Release

zip -j 'RF5StackChopSmash_v1.0.0.zip' './bin/Release/net6.0/RF5StackChopSmash.dll'
cp './bin/Release/net6.0/RF5StackChopSmash.dll' '/data/Steam/steamapps/common/Rune Factory 5/BepInEx/plugins'