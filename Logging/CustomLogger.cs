namespace RestauranteAPI.Logging
{
    public class CustomLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly CustomLoggerProviderConfiguration _configuration;

        public CustomLogger(string nome,
            CustomLoggerProviderConfiguration configuration)
        {
            _loggerName = nome;
            _configuration = configuration;
        }

        public IDisposable BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            var mensagem = string.Format($"{logLevel}: {eventId}" +
                $" - {formatter(state, exception)}");
            WriteTextOnFile(mensagem);
        }

        private void WriteTextOnFile(string mensagem)
        {
            var filePath = @$"C:\Users\JoaoPaulo\source\repos\LanchoneteAPI\RestauranteAPI\RestauranteAPI\bin\LOG-{DateTime.Now:yyyy-MM-dd}.txt";
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.Create(filePath).Dispose();
            }

            using StreamWriter streamWriter = new StreamWriter(filePath, true);
            streamWriter.WriteLine(mensagem);
            streamWriter.Close();
        }
    }
}
