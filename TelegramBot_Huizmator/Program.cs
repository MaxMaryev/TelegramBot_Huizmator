using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramBot;

var client = new TelegramBotClient("6273011124:AAGeDrdgFKSbKc7vcyGNYxtfjnqMQ9IVwbM");
client.StartReceiving(Update, Error);
Console.ReadLine();

async Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
{
    var message = update.Message;

    if (message == null || message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
        return;

    Console.WriteLine(message.Chat.FirstName + "   " + message.Text);

    if (ShouldAnswer(message))
    {
        string answer = Huizmator.SentenceToHuizm(message.Text);

        await botClient.SendTextMessageAsync(message.Chat.Id, answer);
        return;
    }
}

static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
{
    throw new NotImplementedException();
}

bool ShouldAnswer(Message message)
{
    return message.Text.Contains(' ') == false && message.Text.Length > 1 && message.Text[0] != ')';
}