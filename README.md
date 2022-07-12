# MikanRss

解析和反序列化 [Mikan Project](https://mikanani.me/) 的 RSS Feed

## 使用

MikanRss 是基于 .NET Standard 2.0 编写的类库，兼容所有支持 .NET Standard 2.0 标准的 .NET 平台

从 Nuget 安装 [MikanRss](https://www.nuget.org/packages/MikanRss)

``` shell
dotnet add package MikanRss
```

MikanRss 提供了两个反序列化方法重载：

```csharp
public static MikanRss? MikanRss.MikanRssSerializer.Deserialize(string xml);
public static MikanRss? MikanRss.MikanRssSerializer.Deserialize(Stream stream);
```

若反序列化失败，返回值将会是 Null，`MikanRss` 对象中的所有属性均是可空的值，使用前应当先判断值是否为空

## 许可证

本项目使用 [AGPL-3.0 许可证](./LICENSE)

本项目为社区项目，与 [Mikan Project](https://mikanani.me/) 官方没有关联
