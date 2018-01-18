# CodingConnected.TraCI

Currently, this repository is home to two independent implementations of the TraCI protocol (see http://sumo.dlr.de/wiki/TraCI):

- TraCI.NET offers an incomplete, though growing implementation of TraCI in C#/.NET
- TraCI.C offers an even partialler implementation of TraCI in native (ANSI) C (for now, this is Windows only)

The implementation in C# is currently (January 2018) being expanded to include the complete TraCI API. Complete implementation will take a while (orientation: end of March 2018). The implementation in C is oriented exclusively on connecting external traffic controllers to SUMO, and therefor covers only a very small portion of the TraCI API.