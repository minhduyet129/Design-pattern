using Facade.Subsystems;

namespace Facade.Facade;

/// <summary>
/// The Facade class provides a simple interface to the complex logic of one
/// or several subsystems. The Facade delegates the client requests to the
/// appropriate objects within the subsystem. The Facade is also responsible
/// for managing their lifecycle. All of this shields the client from the
/// undesired complexity of the subsystem.
/// </summary>
public class VideoConverter
{
    public string ConvertVideo(string fileName, string format)
    {
        Console.WriteLine($"VideoConverter: conversion started for {fileName} to {format}...");
        
        VideoFile file = new VideoFile(fileName);
        ICodec sourceCodec = CodecFactory.Extract(file);
        
        ICodec destinationCodec;
        if (format == "mp4")
        {
            destinationCodec = new MPEG4CompressionCodec();
        }
        else
        {
            destinationCodec = new OggCompressionCodec();
        }
        
        string buffer = BitrateReader.Read(file, sourceCodec);
        string intermediateResult = BitrateReader.Convert(buffer, destinationCodec);
        string result = (new AudioMixer()).Fix(intermediateResult);
        
        Console.WriteLine("VideoConverter: conversion completed.");
        return result;
    }
}
