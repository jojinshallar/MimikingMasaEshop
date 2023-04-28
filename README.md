[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=jojinshallar_MimikingMasaEshop&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=jojinshallar_MimikingMasaEshop)

使用Masa Framework 1.0.0-rc.1版本+.Net8。
代码照抄：https://github.com/zhenlei520/Masa.EShop.Demo

### 遇到的坑
**1、使用EFCore工具做数据库迁移时，遇到MethodNotFoundException的报错：**
**原因**：Masa.Contrib.Data.EFCore.Sqlite包自动安装的是EFCore6.0版本，但单独安装的Microsoft.EntityFrameworkCore.Design包的版本是7.0.5，应该是版本太低导致。
**解决方案**：单独安装Microsoft.EntityFramworkCore.Sqlite 7.0.5版本的包。

**2、配置Giuhub的Action执行报错：**
**原因**：查看报错输出是因为当前默认的.Net版本是7，但项目依赖的是.Net8。
**解决方案**：在Action的配置中添加安装.Net8的配置，具体脚本如下:

```
env:
  DOTNET_VERSION: '8.0.X' # 配置使用.net8版本编译，否则会报错
jobs:
  build:
    steps:
      - name: Setup .NET
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: ${{ env.DOTNET_VERSION }}
```
