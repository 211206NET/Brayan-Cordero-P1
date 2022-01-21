using UI;
using Serilog;

Log.Logger = new LoggerConfiguration()
// .WriteTo.Console()
.WriteTo.File("../StoreDL/Logger.txt")
.CreateLogger();



MainMenu startmain = new MainMenu();
startmain.mainMenuStart();