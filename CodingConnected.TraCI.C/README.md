# TraCI.NET

A simple (and rather incomplete) implementation of TraCI (see http://sumo.dlr.de/wiki/TraCI) in native (ANSI) C.

** Usage

To use the library, firtst build it, for example with Visual Studio 2017. Make sure the resulting .lib file will be linked to your project at compule time. Now, include the public header file:

    #include "cctracic_public.h"

Now, connect to SUMO.
*Note 1:* This presupposes SUMO or SUMO-GUI has been started with the "--remote-port" option as described in the TraCI documentation.

    TraCIConnect("127.0.0.1", "4001");

If using SUMO-GUI, press the play button after the network has loaded, otherwise no TraCI commands will be handled.
Subsequently, the simulation can be run by calling

    TraCIControlSimStep();

in a loop. Please consult the public header file to see what other functionality exposed by the TraCI API has been implemented.
