// This file is a part of MikanSubscriber project.
// MikanSubsciber is a community project.
// It is not related to Mikan Project.
// Licensed under the AGPL-3.0 license.

using System.Xml.Serialization;

namespace MikanRss.Model;

/// <summary>
///     频道
/// </summary>
/// <remarks>
///     rss -> channel
/// </remarks>
[XmlRoot("channel")]
public class MikanRssChannel
{
    /// <summary>
    ///     标题
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> title
    /// </remarks>
    [XmlElement("title")]
    public string? Title { get; set; }

    /// <summary>
    ///     链接
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> link
    /// </remarks>
    [XmlElement("link")]
    public string? Link { get; set; }

    /// <summary>
    ///     简介
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> description
    /// </remarks>
    [XmlElement("description")]
    public string? Description { get; set; }

    /// <summary>
    ///     包含的项
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item
    /// </remarks>
    [XmlElement("item")]
    public List<MikanRssItem>? Items { get; set; }
}
