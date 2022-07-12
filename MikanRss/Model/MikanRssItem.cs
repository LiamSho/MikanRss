// This file is a part of MikanSubscriber project.
// MikanSubsciber is a community project.
// It is not related to Mikan Project.
// Licensed under the AGPL-3.0 license.

using System.Xml.Serialization;

namespace MikanRss.Model;

/// <summary>
///     项
/// </summary>
/// <remarks>
///     rss -> channel -> item
/// </remarks>
[XmlRoot("item")]
public record MikanRssItem
{
    /// <summary>
    ///     项 ID
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> guid
    /// </remarks>
    [XmlElement("guid")]
    public MikanRssItemGuid? Guid { get; set; }

    /// <summary>
    ///     链接
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> link
    /// </remarks>
    [XmlElement("link")]
    public string? Link { get; set; }

    /// <summary>
    ///     标题
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> title
    /// </remarks>
    [XmlElement("title")]
    public string? Title { get; set; }

    /// <summary>
    ///     简介
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> description
    /// </remarks>
    [XmlElement("description")]
    public string? Description { get; set; }

    /// <summary>
    ///     种子
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> torrent
    /// </remarks>
    [XmlElement("torrent")]
    public MikanRssItemTorrent? Torrent { get; set; }

    /// <summary>
    ///     附件
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> enclosure
    /// </remarks>
    [XmlElement("enclosure")]
    public MikanRssItemEnclosure? Enclosure { get; set; }
}
