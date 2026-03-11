using Bridge.Abstraction;
using Bridge.Implementation;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Bridge Pattern Example ===\n");

        // 1. Create a TV and a simple remote for it
        IDevice tv = new Tv();
        RemoteControl simpleRemote = new RemoteControl(tv);
        
        Console.WriteLine("Client: Testing simple remote with TV...");
        simpleRemote.TogglePower();
        simpleRemote.VolumeUp();
        simpleRemote.ChannelUp();
        simpleRemote.ShowStatus();

        // 2. Create a Radio and an advanced remote for it
        IDevice radio = new Radio();
        AdvancedRemoteControl advancedRemote = new AdvancedRemoteControl(radio);

        Console.WriteLine("Client: Testing advanced remote with Radio...");
        advancedRemote.TogglePower();
        advancedRemote.Mute();
        advancedRemote.ChannelUp();
        advancedRemote.ShowStatus();

        // 3. We can also use the same advanced remote with a TV!
        // This demonstrates that Abstraction and Implementation are decoupled.
        AdvancedRemoteControl advancedRemoteForTv = new AdvancedRemoteControl(tv);
        Console.WriteLine("Client: Testing advanced remote with TV (Switching implementation)...");
        advancedRemoteForTv.VolumeUp();
        advancedRemoteForTv.ShowStatus();
    }
}
