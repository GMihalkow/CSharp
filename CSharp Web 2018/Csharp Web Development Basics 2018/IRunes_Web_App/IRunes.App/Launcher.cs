namespace IRunes.App
{
    using IRunes.App.Controllers;
    using IRunes.App.Views;
    using IRunes.Data;
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer;
    using SIS.WebServer.Routing;
    using System;

    public class Launcher
    {
        static void Main(string[] args)
        {
            ConfigureDatabase();

            Server server = ConfigureServer();

            server.Run();
        }

        private static Server ConfigureServer()
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            ConfigureRoutes(serverRoutingTable);

            Server server = new Server(8002, serverRoutingTable);
            return server;
        }

        private static void ConfigureRoutes(ServerRoutingTable serverRoutingTable)
        {
            //GET Routes
            serverRoutingTable.Routes[HttpRequestMethod.Get].Add("/", request => new HomeController().Index(request));
            serverRoutingTable.Routes[HttpRequestMethod.Get].Add("/Users/Login", request => new AccountController().GetLogin(request));
            serverRoutingTable.Routes[HttpRequestMethod.Get].Add("/Users/Register", request => new AccountController().GetRegister(request));
            serverRoutingTable.Routes[HttpRequestMethod.Get].Add("/Albums/All", request => new AlbumsController().GetAllALbums(request));
            serverRoutingTable.Routes[HttpRequestMethod.Get].Add("/Albums/Create", request => new AlbumsController().GetCreatePage(request));
            serverRoutingTable.Routes[HttpRequestMethod.Get].Add("/Albums/Details", request => new AlbumsController().GetAlbum(request));
            serverRoutingTable.Routes[HttpRequestMethod.Get].Add("/Tracks/Create", request => new TrackController().CreateTrack(request));
            serverRoutingTable.Routes[HttpRequestMethod.Get].Add("/Tracks/Details", request => new TrackController().TrackDetails(request));

            //POST Routes
            serverRoutingTable.Routes[HttpRequestMethod.Post].Add("/Users/Login", request => new AccountController().PostLogin(request));
            serverRoutingTable.Routes[HttpRequestMethod.Post].Add("/Users/Register", request => new AccountController().PostRegister(request));
            serverRoutingTable.Routes[HttpRequestMethod.Post].Add("/Albums/Create", request => new AlbumsController().PostCreateAlbum(request));
            serverRoutingTable.Routes[HttpRequestMethod.Post].Add("/Tracks/Create", request => new TrackController().PostCreateTrack(request));
        }

        private static void ConfigureDatabase()
        {
            IRunesDbContext context = new IRunesDbContext();
            context.Database.Migrate();
        }
    }
}
