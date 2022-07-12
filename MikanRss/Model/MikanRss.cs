// This file is a part of MikanSubscriber project.
// MikanSubsciber is a community project.
// It is not related to Mikan Project.
// Licensed under the AGPL-3.0 license.

using System.Xml.Serialization;

namespace MikanRss.Model;

/// <summary>
///     MikanRss 对象
/// </summary>
/// <remarks>
///     rss
/// </remarks>
[XmlRoot("rss")]
public record MikanRss
{
    /// <summary>
    ///     频道
    /// </summary>
    /// <remarks>
    ///     rss -> channel
    /// </remarks>
    [XmlElement("channel")]
    public MikanRssChannel? Channel { get; set; }
}
