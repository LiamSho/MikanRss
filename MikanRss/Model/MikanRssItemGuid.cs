// This file is a part of MikanSubscriber project.
// MikanSubsciber is a community project.
// It is not related to Mikan Project.
// Licensed under the AGPL-3.0 license.

using System.Xml.Serialization;

namespace MikanRss.Model;

/// <summary>
///     项 ID
/// </summary>
/// <remarks>
///     rss -> channel -> item -> guid
/// </remarks>
[XmlRoot("guid")]
public record MikanRssItemGuid
{
    /// <summary>
    ///     是否为永久链接
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> guid::isPermaLink
    /// </remarks>
    [XmlAttribute("isPermaLink")]
    public bool IsPermaLink { get; set; }

    /// <summary>
    ///     项 ID
    /// </summary>
    /// <remarks>
    ///     rss -> channel -> item -> guid
    /// </remarks>
    [XmlText]
    public string? Content { get; set; }
}
