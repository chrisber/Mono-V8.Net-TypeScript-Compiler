Mono-V8.Net-TypeScript-Compiler
===============================

This is a example project for the  mono port [V8.Net](https://v8dotnet.codeplex.com/).

Note:
This is a prove of concept project to validate the possible port of the
Monodevelop-typescript addin  which uses Javascript .NET to linux.
Javascript .NET is not usable with mono. V8.Net uses p/invoke which makes it platform independent.

This project contains:

- ported libraries of V8.Net
    + V8.Net.dll
    + V8.Net.Proxy.Interface.dll
    + V8.Net.SharedTypes.dll
    + libV8_Net_Proxy.so
- V8 version 3.30.13
    + libicui18n.so
    + libicuuc.so
    + libv8.so

All libraries compiled with Ubuntu 14.04 x64

Execute it form commandline via 
`LD_LIBRARY_PATH="pwd" MONO_LOG_LEVEL=debug MONO_LOG_MASK=all mono testv8.exe
`
