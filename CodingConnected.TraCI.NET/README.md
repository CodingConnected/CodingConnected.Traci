# TraCI.NET

A simple (and rather incomplete) implementation of TraCI (see http://sumo.dlr.de/wiki/TraCI) in C#. 

The library has been written specifically to connect external traffic light controller software to SUMO. Therefore, at this point, only TraCI API functions needed to achieve that goal are exposed through the TraCI.NET API. That basically means: it can run the simulation, read state of "e2" detectors, and set state of traffic lights.

**Usage**

Usage of the library is very straightforward. First, create an instance of the client.


    var client = new TraCIClient();

Now, connect to SUMO.
*Note 1:* This presupposes SUMO or SUMO-GUI has been started with the "--remote-port" option as described in the TraCI documentation.
*Note 2:* This function is implemented asynchronously, to allow a GUI to remain responsive; subsequent API calls are (for now) all synchronous (they should not take a noticable amount of time).

    await client.ConnectAsync("127.0.0.1", 4001);

If using SUMO-GUI, press the play button after the network has loaded, otherwise no TraCI commands will be handled.
We can now run the simulation, for example using a Task:

    Task.Run(() =>
    {
        while (!cancellationTokenSource.IsCancellationRequested)
        {
            Thread.Sleep(100);
            client.ControlSimStep();
        }
    }

This assumes a step size of 0,1 second. The approach is quite rudimentary and does not take into account the call to ControlSimStep might take time.

Browse the public methods off the TraCIClient class to find out which functionality is exposed.
