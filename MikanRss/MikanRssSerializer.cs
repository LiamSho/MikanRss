// This file is a part of MikanSubscriber project.
// MikanSubsciber is a community project.
// It is not related to Mikan Project.
// Licensed under the AGPL-3.0 license.

using System.Xml;
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
    /// <exception cref="InvalidOperationException">RSS XML 字符串无法解析</exception>
    public static Model.MikanRss? Deserialize(string rss)
    {
        using var textReader = new StringReader(rss);
        using var reader = new XmlTextReader(textReader);
        reader.Namespaces = false;
        var serializer = new XmlSerializer(typeof(Model.MikanRss));
        var obj = serializer.Deserialize(reader);

        return obj as Model.MikanRss;
    }
}
