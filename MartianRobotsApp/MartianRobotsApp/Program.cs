

using MartianRobotsApp.Clients;
using MartianRobotsApp.Services;

var parserService = new ParserService();
var inputValidator = new InputValidator();

var consoleApp = new ConsoleApp(parserService, inputValidator);

consoleApp.Run();