#include <sleepy_discord/sleepy_discord.h>
#include <cpr/cpr.h>

#define API_ENDPOINT "https://www.nbcnews.com/politics/2020-elections/president-results?format=json"

std::string getElectionMessage() {
        cpr::Response resp = cpr::Get(cpr::Url{API_ENDPOINT});
        return resp.text;
}

class ElectionBot : public SleepyDiscord::DiscordClient {
public:
        using SleepyDiscord::DiscordClient::DiscordClient;
        void onMessage(SleepyDiscord::Message message) override {
                if (!message.startsWith("!e")) return;
                sendMessage(message.channelID, getElectionMessage());
        }
};

int main() {
        std::ifstream secretfile{"../.secret"};
        std::string secret;
        secretfile >> secret;
        ElectionBot(secret).run();
}
