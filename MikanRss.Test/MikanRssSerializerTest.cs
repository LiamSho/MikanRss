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
        const string Str = """
        <?xml version="1.0" encoding="utf-8"?>
        <rss version="2.0">
            <channel>
                <title>Mikan Project - 夏日重现</title>
                <link>http://mikanani.me/RSS/Bangumi?bangumiId=2711&amp;subgroupid=382</link>
                <description>Mikan Project - 夏日重现</description> 
            </channel>
        </rss>
        """;

        var rss = MikanRssSerializer.Deserialize(Str);

        Assert.NotNull(rss);
        Assert.NotNull(rss!.Channel);
        Assert.Empty(rss.Channel!.Items!);

        Assert.Equal("Mikan Project - 夏日重现", rss!.Channel!.Title);
        Assert.Equal("http://mikanani.me/RSS/Bangumi?bangumiId=2711&subgroupid=382", rss!.Channel!.Link);
        Assert.Equal("Mikan Project - 夏日重现", rss!.Channel!.Description);
    }

    [Fact]
    public void Test_One_Item()
    {
        const string Str = """
        <?xml version="1.0" encoding="utf-8"?>
        <rss version="2.0">
            <channel>
                <title>Mikan Project - 夏日重现</title>
                <link>http://mikanani.me/RSS/Bangumi?bangumiId=2711&amp;subgroupid=382</link>
                <description>Mikan Project - 夏日重现</description> 
                <item>
                    <guid isPermaLink="false">【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][1080p][繁日双语][招募翻译片源]</guid>
                    <link>https://mikanani.me/Home/Episode/d962959e46a761d49ee69a8d66e67f4e85ef72bf</link>
                    <title>【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][1080p][繁日双语][招募翻译片源]</title>
                    <description>【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][1080p][繁日双语][招募翻译片源][692.78 MB]</description>
                    <torrent xmlns="https://mikanani.me/0.1/">
                        <link>https://mikanani.me/Home/Episode/d962959e46a761d49ee69a8d66e67f4e85ef72bf</link>
                        <contentLength>726432512</contentLength>
                        <pubDate>2022-07-08T21:39:07.923</pubDate>
                    </torrent>
                    <enclosure type="application/x-bittorrent" length="726432512" url="https://mikanani.me/Download/20220708/d962959e46a761d49ee69a8d66e67f4e85ef72bf.torrent" />
                </item>
            </channel>
        </rss>
        """;

        var rss = MikanRssSerializer.Deserialize(Str);

        Assert.NotNull(rss);
        Assert.NotNull(rss!.Channel);

        Assert.Single(rss.Channel!.Items!);

        Assert.Equal("Mikan Project - 夏日重现", rss!.Channel!.Title);
        Assert.Equal("http://mikanani.me/RSS/Bangumi?bangumiId=2711&subgroupid=382", rss!.Channel!.Link);
        Assert.Equal("Mikan Project - 夏日重现", rss!.Channel!.Description);

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
        const string Str = """
        <?xml version="1.0" encoding="utf-8"?>
        <rss version="2.0">
            <channel>
                <title>Mikan Project - 夏日重现</title>
                <link>http://mikanani.me/RSS/Bangumi?bangumiId=2711&amp;subgroupid=382</link>
                <description>Mikan Project - 夏日重现</description> 
                <item>
                    <guid isPermaLink="false">【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][1080p][繁日双语][招募翻译片源]</guid>
                    <link>https://mikanani.me/Home/Episode/d962959e46a761d49ee69a8d66e67f4e85ef72bf</link>
                    <title>【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][1080p][繁日双语][招募翻译片源]</title>
                    <description>【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][1080p][繁日双语][招募翻译片源][692.78 MB]</description>
                    <torrent xmlns="https://mikanani.me/0.1/">
                        <link>https://mikanani.me/Home/Episode/d962959e46a761d49ee69a8d66e67f4e85ef72bf</link>
                        <contentLength>726432512</contentLength>
                        <pubDate>2022-07-08T21:39:07.923</pubDate>
                    </torrent>
                    <enclosure type="application/x-bittorrent" length="726432512" url="https://mikanani.me/Download/20220708/d962959e46a761d49ee69a8d66e67f4e85ef72bf.torrent" />
                </item>
                <item>
                    <guid isPermaLink="false">【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][1080p][简日双语][招募翻译片源]</guid>
                    <link>https://mikanani.me/Home/Episode/16deb03b0c971c04d1df4cb7013e270f6c9e836f</link>
                    <title>【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][1080p][简日双语][招募翻译片源]</title>
                    <description>【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][1080p][简日双语][招募翻译片源][692.91 MB]</description>
                    <torrent xmlns="https://mikanani.me/0.1/">
                        <link>https://mikanani.me/Home/Episode/16deb03b0c971c04d1df4cb7013e270f6c9e836f</link>
                        <contentLength>726568768</contentLength>
                        <pubDate>2022-07-08T21:37:41.572</pubDate>
                    </torrent>
                    <enclosure type="application/x-bittorrent" length="726568768" url="https://mikanani.me/Download/20220708/16deb03b0c971c04d1df4cb7013e270f6c9e836f.torrent" />
                </item>
                <item>
                    <guid isPermaLink="false">【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][720p][繁日双语][招募翻译片源]</guid>
                    <link>https://mikanani.me/Home/Episode/e761b5d8a3f58aa276f2d63b959f780c1261881f</link>
                    <title>【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][720p][繁日双语][招募翻译片源]</title>
                    <description>【喵萌奶茶屋】★04月新番★[夏日重现/Summer Time Rendering][13][720p][繁日双语][招募翻译片源][294.35 MB]</description>
                    <torrent xmlns="https://mikanani.me/0.1/">
                        <link>https://mikanani.me/Home/Episode/e761b5d8a3f58aa276f2d63b959f780c1261881f</link>
                        <contentLength>308648352</contentLength>
                        <pubDate>2022-07-08T07:57:22.067</pubDate>
                    </torrent>
                    <enclosure type="application/x-bittorrent" length="308648352" url="https://mikanani.me/Download/20220708/e761b5d8a3f58aa276f2d63b959f780c1261881f.torrent" />
                </item>
            </channel>
        </rss>
        """;

        var rss = MikanRssSerializer.Deserialize(Str);

        Assert.NotNull(rss);
        Assert.NotNull(rss!.Channel);

        Assert.Equal(3, rss.Channel!.Items!.Count);
    }
}
