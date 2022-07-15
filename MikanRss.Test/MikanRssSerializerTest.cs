// This file is a part of MikanRss project.\MikanRss is a community project.
// It is not related to Mikan Project.
// Licensed under the AGPL-3.0 license.

using System.Xml;
using Xunit;

namespace MikanRss.Test;

public class MikanRssSerializerTest
{
    [Fact]
    public void Test_Empty_String()
    {
        try
        {
            var _ = MikanRssSerializer.Deserialize("");
        }
        catch (Exception e)
        {
            Assert.IsType<InvalidOperationException>(e);
            Assert.IsType<XmlException>(e.InnerException);
        }
    }

    [Fact]
    public void Test_Empty_Xml()
    {
        try
        {
            var _ = MikanRssSerializer.Deserialize("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        }
        catch (Exception e)
        {
            Assert.IsType<InvalidOperationException>(e);
            Assert.IsType<XmlException>(e.InnerException);
        }
    }

    [Fact]
    public void Test_Root_Only()
    {
        try
        {
            var _ = MikanRssSerializer.Deserialize("<?xml version=\"1.0\" encoding=\"utf-8\"?><root>Value</root>");
        }
        catch (Exception e)
        {
            Assert.IsType<InvalidOperationException>(e);
            Assert.IsType<InvalidOperationException>(e.InnerException);
        }
    }

    [Fact]
    public void Test_Root_Only_Rss()
    {
        var rss = MikanRssSerializer.Deserialize(
            "<?xml version=\"1.0\" encoding=\"utf-8\"?><rss version=\"2.0\"></rss>");
        Assert.NotNull(rss);
        Assert.Null(rss!.Channel);
    }

    [Fact]
    public void Test_No_Item()
    {
        var str = File.ReadAllText(Path.Combine("Resources", "Test_No_Item.xml")).ReplaceLineEndings(string.Empty);

        var rss = MikanRssSerializer.Deserialize(str);

        Assert.NotNull(rss);
        Assert.NotNull(rss!.Channel);
        Assert.Empty(rss.Channel!.Items!);

        Assert.Equal("Mikan Project - 夏日重现", rss.Channel!.Title);
        Assert.Equal("http://mikanani.me/RSS/Bangumi?bangumiId=2711&subgroupid=382", rss.Channel!.Link);
        Assert.Equal("Mikan Project - 夏日重现", rss.Channel!.Description);
    }

    [Fact]
    public void Test_One_Item()
    {
        var str = File.ReadAllText(Path.Combine("Resources", "Test_One_Item.xml")).ReplaceLineEndings(string.Empty);

        var rss = MikanRssSerializer.Deserialize(str);

        Assert.NotNull(rss);
        Assert.NotNull(rss!.Channel);

        Assert.Single(rss.Channel!.Items!);

        Assert.Equal("Mikan Project - 夏日重现", rss.Channel!.Title);
        Assert.Equal("http://mikanani.me/RSS/Bangumi?bangumiId=2711&subgroupid=382", rss.Channel!.Link);
        Assert.Equal("Mikan Project - 夏日重现", rss.Channel!.Description);

        var item = rss.Channel!.Items![0];

        Assert.Equal("【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][1080p][繁日双语][招募翻译片源]", item.Title);
        Assert.Equal("https://mikanani.me/Home/Episode/d962959e46a761d49ee69a8d66e67f4e85ef72bf", item.Link);
        Assert.Equal("【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][1080p][繁日双语][招募翻译片源][692.78 MB]", item.Description);

        Assert.Equal("https://mikanani.me/Home/Episode/d962959e46a761d49ee69a8d66e67f4e85ef72bf", item.Torrent!.Link);
        Assert.Equal(726432512, item.Torrent!.ContentLength);
        Assert.Equal(new DateTime(2022, 7, 8, 21, 39, 7, 923), item.Torrent!.PublishTime);
        Assert.Equal("https://mikanani.me/0.1/", item.Torrent!.Xmlns);

        Assert.False(item.Guid!.IsPermaLink);
        Assert.Equal("【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][1080p][繁日双语][招募翻译片源]", item.Guid!.Content);

        Assert.Equal("application/x-bittorrent", item.Enclosure!.Type);
        Assert.Equal(726432512, item.Enclosure!.Length);
        Assert.Equal("https://mikanani.me/Download/20220708/d962959e46a761d49ee69a8d66e67f4e85ef72bf.torrent", item.Enclosure!.Url);
    }

    [Fact]
    public void Test_Full_Spec()
    {
        var str = File.ReadAllText(Path.Combine("Resources", "Test_Full_Spec.xml")).ReplaceLineEndings(string.Empty);

        var rss = MikanRssSerializer.Deserialize(str);

        Assert.NotNull(rss);
        Assert.NotNull(rss!.Channel);

        Assert.Equal(3, rss.Channel!.Items!.Count);
    }
}
