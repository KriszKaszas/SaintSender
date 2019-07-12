//Before anyone gets a heart attack, this is meant to be a joke.

using System;

namespace SaintSender.Core
{
    public class EgoBoostMessage
    {
        public string[] Message { get; set; } = 
        { "You are a good person, and people say nice things about you. :)",
        "You are more fun than anyone or anything I know, including bubble wrap. :)",
        "You are the most perfect you there is. :)",
        "I appreciate our friendship. :)",
        "Your inside is even more beautiful than your outside. :)",
        "Our family/school/community/church is better because you are part of it. :)",
        "You are [insert nice thing here]",
        "You are an excellent friend. :)",
        "You make me want to be a better person. :)",
        "You look so young! :)",
        "I hope you are proud of yourself, because I am! :)",
        "You are so trustworthy; I always believe what you say. :)",
        "I know that you will always have my back, because that is the kind of person you are. :)",
        "You have the best ideas. :)",
        "You are a great example to others. :)",
        "I know that if you ever make a mistake, you fix it. :)",
        "You’ve got great leadership skills. :)",
        "You have amazing creative potential.",
        "You really seem to know who you are. I admire that. :)",
        "You are the reason I am smiling today. :)",
        "You’re a gift to everyone you meet. :)",
        "I enjoy spending time with you. :)",
        "I am really glad we met. :)",
        "I tell everyone how amazing you are. :)"
        };

        public string ChooseRandomMessage()
        {
            Random rnd = new Random();
            var randomMessageIndex = rnd.Next(Message.Length);
            return Message[randomMessageIndex];

        }
    }
}
