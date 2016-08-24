# About
This repository contains a demo project which demonstrates the problem with searching in natively compiled UWP apps using SQLite and Entity Framework Core.

## Steps to reproduce
1. Build and run the app in DEBUG configuration (no .NET Native Toolchain by default)
2. Type 'a' in the text box and click 'Search'
3. Observe the results
4. Build and run the app in RELEASE configuration (with .NET Native Toolchain)
5. Repeat steps 2 and 3