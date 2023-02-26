using System.IO;
using System.Xml.Serialization;
using System;

public static class Serializer<T>
{
    public static void Save(string path, T data)
    {
        XmlSerializer formatter = new XmlSerializer(typeof(T));

        using (var stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
        {
            formatter.Serialize(stream, data);
        }
    }

    public static T Load(string path)
    {
        Type type = typeof(T);
        T retVal;

        XmlSerializer formatter = new XmlSerializer(type);

        using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            retVal = (T)formatter.Deserialize(stream);
        }

        return retVal;
    }
}