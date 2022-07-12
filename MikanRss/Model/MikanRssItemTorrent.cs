// This file is a part of MikanSubscriber project.
// MikanSubsciber is a community project.
// It is not related to Mikan Project.
// Licensed under the AGPL-3.0 license.

using System.Xml.Serialization;

namespace MikanRss.Model;

/// <summary>
///     种子
/// </summary>
/// <remarks>
///     rss -> channel -> item -> torrent
/// </remarks>
[XmlRoot("torrent")]
public record MikanRssItemTorrent
{
    /// <summary>
    ///     XML 命名空间
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> torrent::xmlns
    /// </remarks>
    [XmlAttribute("xmlns")]
    public string? Xmlns { get; set; }

    /// <summary>
    ///     链接
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> torrent -> link
    /// </remarks>
    [XmlElement("link")]
    public string? Link { get; set; }

    /// <summary>
    ///     数据量
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> torrent -> length
    /// </remarks>
    [XmlElement("contentLength")]
    public long? ContentLength { get; set; }

    /// <summary>
    ///     发布日期
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> torrent -> pubDate
    /// </remarks>
    [XmlElement("pubDate")]
    public DateTime PublishTime { get; set; }
}
