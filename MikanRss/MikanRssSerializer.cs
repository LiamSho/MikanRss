// This file is a part of MikanSubscriber project.
// MikanSubsciber is a community project.
// It is not related to Mikan Project.
// Licensed under the AGPL-3.0 license.

using System.Text;
using System.Xml.Serialization;

namespace MikanRss;

/// <summary>
///     MikanRss 序列化类
/// </summary>
public static class MikanRssSerializer
{
    /// <summary>
    ///     从 XML 字符串反序列化 <see cref="Model.MikanRss"/> 对象
    /// </summary>
    /// <param name="rss">RSS XML 字符串</param>
    /// <returns><see cref="MikanRss"/> 对象或 NULL</returns>
    public static Model.MikanRss? Deserialize(string rss)
    {
        var buff = Encoding.UTF8.GetBytes(rss);
        var stream = new MemoryStream(buff);
        var obj = Deserialize(stream);
        stream.Close();
        return obj;
    }

    /// <summary>
    ///     从 <see cref="Stream"/> 反序列化 <see cref="Model.MikanRss"/> 对象
    /// </summary>
    /// <param name="rssStream">RSS XML <see cref="Stream"/></param>
    /// <returns><see cref="MikanRss"/> 对象或 NULL</returns>
    public static Model.MikanRss? Deserialize(Stream rssStream)
    {
        var xml = new XmlSerializer(typeof(Model.MikanRss));
        var obj = xml.Deserialize(rssStream);

        return obj as Model.MikanRss;
    }
}
