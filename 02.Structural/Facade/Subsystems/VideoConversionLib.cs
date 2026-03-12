namespace Facade.Subsystems;

public class VideoFile
{
    public string Name { get; private set; }
    public string CodecType { get; private set; }

    public VideoFile(string name)
    {
        Name = name;
        CodecType = name.Substring(name.IndexOf(".") + 1);
    }
}

public interface ICodec { }

public class MPEG4CompressionCodec : ICodec
{
    public string Type => "mp4";
}

public class OggCompressionCodec : ICodec
{
    public string Type => "ogg";
}

public class CodecFactory
{
    public static ICodec Extract(VideoFile file)
    {
        string type = file.CodecType;
        if (type == "mp4")
        {
            Console.WriteLine("CodecFactory: extracting mpeg audio...");
            return new MPEG4CompressionCodec();
        }
        else
        {
            Console.WriteLine("CodecFactory: extracting ogg audio...");
            return new OggCompressionCodec();
        }
    }
}

public class BitrateReader
{
    public static string Read(VideoFile file, ICodec codec)
    {
        Console.WriteLine("BitrateReader: reading file...");
        return "buffer";
    }

    public static string Convert(string buffer, ICodec codec)
    {
        Console.WriteLine("BitrateReader: writing file...");
        return "file";
    }
}

public class AudioMixer
{
    public string Fix(string result)
    {
        Console.WriteLine("AudioMixer: fixing audio...");
        return "final_file";
    }
}
