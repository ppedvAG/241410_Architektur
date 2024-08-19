using HalloSingelton;

Console.WriteLine("Hello Singelton");

for (int i = 0; i < 10; i++)
{
    Task.Run(() => Logger.Instance.LogInfo("Halloooo"));
}

Logger.Instance.LogInfo("Toller Singelton");
