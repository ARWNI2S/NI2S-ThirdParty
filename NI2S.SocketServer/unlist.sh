version=$1
nuget delete NI2S.SocketServer.Client.Proxy "$version" -source nuget.org -NonInteractive
nuget delete NI2S.SocketServer.Client "$version" -source nuget.org -NonInteractive
nuget delete NI2S.SocketServer.WebSocket.Server "$version" -source nuget.org -NonInteractive
nuget delete NI2S.SocketServer.WebSocket "$version" -source nuget.org -NonInteractive
nuget delete NI2S.SocketServer.Server "$version" -source nuget.org -NonInteractive
nuget delete NI2S.SocketServer.SessionContainer "$version" -source nuget.org -NonInteractive
nuget delete NI2S.SocketServer.Command "$version" -source nuget.org -NonInteractive
nuget delete NI2S.SocketServer.Channel "$version" -source nuget.org -NonInteractive
nuget delete NI2S.SocketServer.Primitives "$version" -source nuget.org -NonInteractive
nuget delete NI2S.SocketServer.Protocol "$version" -source nuget.org -NonInteractive