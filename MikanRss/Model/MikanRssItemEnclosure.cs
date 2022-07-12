// This file is a part of MikanSubscriber project.
// MikanSubsciber is a community project.
// It is not related to Mikan Project.
// Licensed under the AGPL-3.0 license.

using System.Xml.Serialization;

namespace MikanRss.Model;

/// <summary>
///     附件
/// </summary>
/// <remarks>
///     rss -> channel -> item -> enclosure
/// </remarks>
[XmlRoot("enclosure")]
public record MikanRssItemEnclosure
{
    /// <summary>
    ///     附件 MIME 类型
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> enclosure::type
    /// </remarks>
    [XmlAttribute("type")]
    public string? Type { get; set; }

    /// <summary>
    ///     数据量
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> enclosure::length
    /// </remarks>
    [XmlAttribute("length")]
    public long? Length { get; set; }

    /// <summary>
    ///     附件 URL
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> enclosure::url
    /// </remarks>
    [XmlAttribute("url")]
    public string? Url { get; set; }
}
